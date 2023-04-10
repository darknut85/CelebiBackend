using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Interfaces;
using Objects;
using Services;

namespace Celebi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public IActionResult ListUsers() 
        {
            List<IdentityUser> users = _userService.GetUsers();
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
            IdentityUser? user = _userService.getUser(userName);
            if (user == null) 
            {
                return BadRequest("User does not exist");
            }
            return Ok(user);
        }

        [HttpGet("GetRoleOfUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRoleOfUser(string userName) 
        { 
            string role = _userService.GetRole(userName);
            
            if (role != null)
            {
                Role roleModel = new()
                {
                    Name = role
                };
                return Ok(roleModel);
            }
            return BadRequest("User does not exist");
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredential userCredential) 
        {
            string token = await _userService.login(userCredential);
            
            if (token == "")
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            bool completed = await _userService.register(register);
            if (completed) 
            {
                return Ok("User created");
            }
            else
            {
                return BadRequest("User wasn't created");
            }

        }
    }
}
