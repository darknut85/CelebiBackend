using Celebi.Api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Services;
using Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Celebi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public TokenController(IJwtTokenManager jwtTokenManager, UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUserService userService)
        {
            _jwtTokenManager = jwtTokenManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult ListUsers() 
        {
            var users = _userService.getUsers();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredential userCredential) 
        {
            var token = _jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
            {
                return BadRequest("User already exists: " + register.Username);
            }
            else
            {
                IdentityUser user = new()
                {
                    Email = register.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = register.Username,
                    NormalizedEmail= register.Email,
                    NormalizedUserName = register.Username
                };
                var result = _userManager.CreateAsync(user, register.Password);

                await result;

                if (result.IsCompletedSuccessfully)
                {
                    var newUser = await _userManager.FindByNameAsync(register.Username);
                    var roleExists = await _roleManager.RoleExistsAsync("User");
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("User"));
                    }
                    await _userManager.AddToRoleAsync(newUser, "User");
                    return Ok("User created");
                }
                else
                {
                    return BadRequest("User wasn't created");
                }
            }
        }
    }
}
