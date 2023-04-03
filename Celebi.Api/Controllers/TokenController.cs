using Celebi.Api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Interfaces;

namespace Celebi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public TokenController(IJwtTokenManager jwtTokenManager, UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUserService userService)
        {
            _jwtTokenManager = jwtTokenManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public IActionResult ListUsers() 
        {
            var users = _userService.getUsers();
            if (users == null)
            {
                return BadRequest("No users found");
            }
            return Ok(users);
        }

        [HttpGet("GetOneUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult FindUser(string userName)
        {
            var user = _userService.getUser(userName);
            if (user == null) 
            {
                return BadRequest("User does not exist");
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredential userCredential) 
        {
            string role = "Joker";
            var newUser = await _userManager.FindByNameAsync(userCredential.UserName);
            IList<string> roles = await _userManager.GetRolesAsync(newUser);

            foreach (var item in roles) { role = item; }

            var token = _jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password, role);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var roleExists = await _roleManager.RoleExistsAsync("User");
            var adminExists = await _roleManager.RoleExistsAsync("Admin");
            if (!roleExists) { await _roleManager.CreateAsync(new IdentityRole("User")); }
            if (!adminExists) { await _roleManager.CreateAsync(new IdentityRole("Admin")); }

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
                    await _userManager.AddToRoleAsync(newUser, register.Role);
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
