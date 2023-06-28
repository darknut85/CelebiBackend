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
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration? _configuration;

        public UserService(DataContext dataContext, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration? configuration = null) 
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
            return _dataContext.Set<IdentityUser>().OrderBy(x => x.Id).ToList();
        }

        public async Task<bool> UpdateEmail(string userName, string newMail)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return false;
            }

            user.Email = newMail;

            var updated = await _userManager.UpdateAsync(user);

            return updated.Succeeded;
        }

        public async Task<bool> UpdatePassword(string userName, string currentPassword, string newPassword)
        {
            Task<IdentityResult> identity = _userManager.ChangePasswordAsync(GetUser(userName), currentPassword, newPassword);
            identity.Wait();
            return identity.IsCompletedSuccessfully;
        }

        //public IdentityUser UpdateUsername(IdentityUser user, string currentUsername, string newUsername) { }

        public IList<string> GetRoles(IdentityUser user)
        {
            Task<IList<string>>? roles = _userManager.GetRolesAsync(user);
            roles.Wait();
            IList<string>? result = roles.Result;
            return result;
        }

        public async Task<bool> Register(Register register)
        {
            await CreateStandardRoles();

            IdentityUser? userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
            {
                return false;
            }
            IdentityRole? roleExists = await _roleManager.FindByNameAsync(register.Role);
            if (roleExists == null)
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

                IdentityUser? newUser = await _userManager.FindByNameAsync(register.Username);
                Task<IdentityResult> irole = _userManager.AddToRoleAsync(newUser, register.Role);

                irole.Wait();

                return irole.IsCompletedSuccessfully;           
            }
        }

        public async Task<string> Login(UserCredential userCredential)
        {
            string role = "";
            IdentityUser? newUser = await _userManager.FindByNameAsync(userCredential.UserName);

            await AddRoleToUser("Admin", "RealAdmin");

            IList<string> roles = await _userManager.GetRolesAsync(newUser);

            foreach (var item in roles) { role = item; }

            return Authenticate(userCredential.UserName, userCredential.Password, role);
        }

        public async Task<string> AddRoleToUser(string role, string userName)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(userName);
            if (user.UserName == "")
                return "The user does not exist";

            IList<string> roles = GetRoles(user);

            IQueryable<IdentityRole> roleExists = _roleManager.Roles;

            IdentityRole? irole = roleExists.Where(x => x.Name.Equals(role)).FirstOrDefault();
            if (irole == null) 
                return "The role does not exist";

            string? hasRole = roles.Where(x => x == role).FirstOrDefault();
            if (hasRole != null)
                return "The user already as the role";

            Task<IdentityResult> iresult = _userManager.AddToRoleAsync(user, role);
            iresult.Wait();
            if (iresult.IsCompletedSuccessfully)
            {
                return "The role has been added to the user";
            }
            return "The role has not been added to the user";
        }

        public async Task<string> RemoveRoleFromUser(string role, string userName)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(userName);
            if (user.UserName == "")
                return "The user does not exist";

            IList<string> roles = GetRoles(user);

            IQueryable<IdentityRole> roleExists = _roleManager.Roles;

            IdentityRole? irole = roleExists.Where(x => x.Name.Equals(role)).FirstOrDefault();
            if (irole == null)
                return "The role does not exist";

            Task<IdentityResult> iresult = _userManager.RemoveFromRoleAsync(user, role);
            iresult.Wait();

            if (iresult.IsCompletedSuccessfully)
            {
                return "The role has been removed from the user";
            }
            return "The role has not been removed from the user";
        }



        [ExcludeFromCodeCoverage]
        private async Task CreateStandardRoles()
        {
            bool roleExists = await _roleManager.RoleExistsAsync("User");
            bool adminExists = await _roleManager.RoleExistsAsync("Admin");
            if (!roleExists) { await _roleManager.CreateAsync(new IdentityRole("User")); }
            if (!adminExists) { await _roleManager.CreateAsync(new IdentityRole("Admin")); }
        }

        [ExcludeFromCodeCoverage]
        public string Authenticate(string username, string password, string userRole = "User")
        {
            IdentityUser loginUser = GetUser(username);

            if (loginUser.UserName == "")
                return "";

            PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(loginUser, loginUser.PasswordHash, password);

            if (passresult != PasswordVerificationResult.Success)
                return "";

            string? configString = _configuration?.GetValue<string>("JwtConfig:key");

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
                Issuer = _configuration?["JwtConfig:Issuer"],
                Audience = _configuration?["JwtConfig:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
