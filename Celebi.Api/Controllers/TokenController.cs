﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetAllRoles")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllRoles()
        {
            IList<string> roles = _userService.GetRoles();

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
            try
            {

                string token = await _userService.Login(userCredential);

                if (token == "")
                {
                    return BadRequest("Combination of username and password is invalid");
                }
                return Ok(token);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            string result = await _userService.Register(register);
            return Ok(result);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string userName, string oldPassword, string newPassword)
        {
            string result = await _userService.UpdatePassword(userName, oldPassword, newPassword);
            Role role = new();
            role.Name = result;
            return Ok(role);
        }

        [HttpPut("ChangeEmail")]
        public async Task<IActionResult> ChangeEmail(string userName, string newEmail)
        {
            string result = await _userService.UpdateEmail(userName, newEmail);
            Role role = new();
            role.Name = result;
            return Ok(role);
        }

        [HttpPut("ChangeUserName")]
        public async Task<IActionResult> ChangeUserName(string userName, string newName)
        {
            string result = await _userService.UpdateUsername(userName, newName);
            Role role = new();
            role.Name = result;
            return Ok(role);
        }

        [HttpGet("Roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(string userName, string role )
        {
            var message = await _userService.AddRoleToUser(role, userName);

            Role mess = new() { Name = message };

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
                return Ok(mess);
            }
            return Ok(mess);
        }
    }
}
