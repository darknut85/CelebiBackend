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

        public string Authenticate(string username, string password, string userRole = "User")
        {
            List<IdentityUser> iuser = _userService.GetUsers();
            if (!iuser.Any(x => x.UserName.Equals(username)))
            {
                return null;
            }

            var loginUser = iuser.FirstOrDefault(x => x.UserName == username);

            PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(loginUser, loginUser.PasswordHash, password);

            if (passresult != PasswordVerificationResult.Success)
            {
                return null;
            }

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtConfig:key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, userRole)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _configuration["JwtConfig:Issuer"],
                Audience = _configuration["JwtConfig:Audience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = credentials
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
