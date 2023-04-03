using Microsoft.AspNetCore.Identity;
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
        IdentityUser getUser(string username);

        //get users
        List<IdentityUser> GetUsers();

        //get role of user
        string GetRole(string username);

        //register user

        //check if user exists

        //delete user
    }
}
