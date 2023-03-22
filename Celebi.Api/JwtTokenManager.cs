using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Celebi.Api
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public JwtTokenManager(IConfiguration configuration, IUserService userService, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userService = userService;
            _userManager = userManager;
        }

        public string Authenticate(string username, string password)
        {
            //password needs to be hashed to compare
            List<IdentityUser> iuser = _userService.getUsers();
            if (!iuser.Any(x => x.UserName.Equals(username)))// && x.PasswordHash.Equals(password)))
            {
                return null;
            }

            var loginUser = iuser.FirstOrDefault(x => x.UserName == username);

            //string hash = loginUser.PasswordHash;
            PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(loginUser, loginUser.PasswordHash, password);

            Debug.WriteLine(loginUser.PasswordHash);
            Debug.WriteLine(password);
            if (passresult != PasswordVerificationResult.Success)
            {
                return null;
            }

            var key = _configuration.GetValue<string>("JwtConfig:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string HashPassword(string password) 
        { 
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
    }
}
