using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Migrations;
using Objects;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    [ExcludeFromCodeCoverage]
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(DataContext dataContext, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration) 
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public IdentityUser GetUser(string username)
        {
            IdentityUser? identity = _dataContext.Set<IdentityUser>().FirstOrDefault(x => x.UserName == username);
            if (identity != null) 
            {
                return identity;
            }
            return new IdentityUser("");
        }

        public List<IdentityUser> GetUsers()
        {
            var data = _dataContext.Set<IdentityRole>().ToList();
            foreach (var item in data)
            {
                Debug.WriteLine(item);
            }
            Debug.WriteLine("Debug works");

            return _dataContext.Set<IdentityUser>().OrderBy(x => x.Id).ToList();
        }

        public string GetRole(string username)
        {
            IdentityUser user = GetUser(username);

            if (user == null || user.UserName == "")
            {
                return "";
            }

            IList<string> roles = GetRoles(user);

            string r = "";
            foreach (var role in roles) 
            { 
                r = role;
                break;
            }

            return r;
        }

        public IList<string> GetRoles(IdentityUser user)
        {
            Task<IList<string>>? roles = _userManager.GetRolesAsync(user);
            roles.Wait();
            IList<string>? result = roles.Result;
            return result;
        }

        public async Task<bool> Register(Register register)
        {

            bool roleExists = await _roleManager.RoleExistsAsync("User");
            bool adminExists = await _roleManager.RoleExistsAsync("Admin");
            if (!roleExists) { await _roleManager.CreateAsync(new IdentityRole("User")); }
            if (!adminExists) { await _roleManager.CreateAsync(new IdentityRole("Admin")); }

            IdentityUser? userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
            {
                return false;
            }
            else
            {
                IdentityUser user = new()
                {
                    Email = register.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = register.Username,
                    NormalizedEmail = register.Email,
                    NormalizedUserName = register.Username
                };
                Task<IdentityResult> result = _userManager.CreateAsync(user, register.Password);

                await result;

                if (result.IsCompletedSuccessfully)
                {
                    IdentityUser? newUser = await _userManager.FindByNameAsync(register.Username);
                    await _userManager.AddToRoleAsync(newUser, register.Role);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<string> Login(UserCredential userCredential)
        {
            string role = "";
           IdentityUser? newUser = await _userManager.FindByNameAsync(userCredential.UserName);
            IList<string> roles = await _userManager.GetRolesAsync(newUser);

            foreach (var item in roles) { role = item; }

            return Authenticate(userCredential.UserName, userCredential.Password, role);
        }

        public string Authenticate(string username, string password, string userRole = "User")
        {
            List<IdentityUser> iuser = GetUsers();
            if (!iuser.Any(x => x.UserName.Equals(username)))
                return "";

            IdentityUser? loginUser = iuser.FirstOrDefault(x => x.UserName == username);

            if (loginUser == null)
                return "";

            PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(loginUser, loginUser.PasswordHash, password);

            if (passresult != PasswordVerificationResult.Success)
                return "";

            string? configString = _configuration.GetValue<string>("JwtConfig:key");

            if (configString == null)
                return "";

            SymmetricSecurityKey? securityKey = new(Encoding.ASCII.GetBytes(configString));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, userRole)
            };

            JwtSecurityTokenHandler tokenHandler = new();

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = _configuration["JwtConfig:Issuer"],
                Audience = _configuration["JwtConfig:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentials
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
