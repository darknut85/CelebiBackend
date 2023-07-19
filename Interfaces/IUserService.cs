using Microsoft.AspNetCore.Identity;
using Objects;

namespace Interfaces
{
    public interface IUserService
    {
        //get user
        IdentityUser GetUser(string username);

        //get users
        List<IdentityUser> GetUsers();

        //get all roles of user
        IList<string> GetRoles(IdentityUser user);

        //get all roles
        IList<string> GetRoles();

        //register user
        Task<string> Register(Register register);

        //login user
        Task<string> Login(UserCredential userCredential);

        //authenticate
        string Authenticate(string username, string password, string role = "User");

        //update password
        Task<string> UpdatePassword(string userName, string currentPassword, string newPassword);

        //update email
        Task<string> UpdateEmail(string userName, string newMail);

        //update username
        Task<string> UpdateUsername(string userName, string newName);

        //add role to user
        Task<string> AddRoleToUser(string role, string userName);

        //remove role from user
        Task<string> RemoveRoleFromUser(string role, string userName);
    }
}
