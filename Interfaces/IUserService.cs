using Microsoft.AspNetCore.Identity;
using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserService
    {
        //get user
        IdentityUser GetUser(string username);

        //get users
        List<IdentityUser> GetUsers();

        //get first role of user
        string GetRole(string username);

        //get all roles of user
        IList<string> GetRoles(IdentityUser user);

        //register user
        Task<bool> Register(Register register);

        //login user
        Task<string> Login(UserCredential userCredential);

        //authenticate
        string Authenticate(string username, string password, string role = "User");

        //check if user exists

        //delete user
    }
}
