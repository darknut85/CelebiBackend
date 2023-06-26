using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Interfaces;
using Objects;

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
            IdentityUser? user = _userService.GetUser(userName);
            if (user == null) 
            {
                return BadRequest("User does not exist");
            }
            return Ok(user);
        }

        [HttpGet("GetSelf")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult FindSelf(string userName)
        {
            IdentityUser? user = _userService.GetUser(userName);
            if (user == null)
            {
                return BadRequest("User does not exist");
            }
            return Ok(user);
        }

        [HttpGet("GetRolesOfUser")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetRolesOfUser(string userName) 
        { 
            IdentityUser user = _userService.GetUser(userName);
            IList<string> roles = _userService.GetRoles(user);
            
            if (roles != null)
            {
                return Ok(roles);
            }
            return BadRequest("User does not exist");
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredential userCredential) 
        {
            string token = await _userService.Login(userCredential);
            
            if (token == "")
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            bool completed = await _userService.Register(register);
            if (!completed)
            {
                return BadRequest("User wasn't created");
            }
            return Ok("User created");
        }

        [HttpGet("Roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(string userName, string role )
        {
            var message = await _userService.AddRoleToUser(role, userName);

            Role mess = new() { Name = message };

            if (mess.Name != "The role has been added to the user")
            {
                return BadRequest(mess);
            }
            return Ok(mess);
        }

        [HttpDelete("Roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRole(string userName, string role)
        {
            var message = await _userService.RemoveRoleFromUser(role, userName);

            Role mess = new() { Name = message };

            if (mess.Name != "The role has been removed from the user")
            {
                return BadRequest(mess);
            }
            return Ok(mess);
        }
    }
}
