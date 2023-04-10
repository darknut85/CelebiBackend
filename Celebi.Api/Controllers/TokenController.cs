﻿using Celebi.Api.models;
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
            var users = _userService.GetUsers();
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

        [HttpGet("GetRoleOfUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRoleOfUser(string userName) 
        { 
            string role = _userService.GetRole(userName);
            
            if (role != null)
            {
                Role roleModel = new Role();
                roleModel.Name = role;
                return Ok(roleModel);
            }
            return BadRequest("User does not exist");
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
