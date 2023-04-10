﻿using Interfaces;
using Microsoft.AspNetCore.Identity;
using Migrations;
using Objects;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Services
{
    [ExcludeFromCodeCoverage]
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenManager _jwtTokenManager;

        public UserService(DataContext dataContext, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IJwtTokenManager jwtTokenManager) 
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenManager = jwtTokenManager;
        }

        public IdentityUser getUser(string username)
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
            IdentityUser user = getUser(username);

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

        public async Task<bool> register(Register register)
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

        public async Task<string> login(UserCredential userCredential)
        {
            string role = "";
           IdentityUser? newUser = await _userManager.FindByNameAsync(userCredential.UserName);
            IList<string> roles = await _userManager.GetRolesAsync(newUser);

            foreach (var item in roles) { role = item; }

            return _jwtTokenManager.Authenticate(userCredential.UserName, userCredential.Password, role);
        }
    }
}