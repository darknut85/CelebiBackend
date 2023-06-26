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

        //register user
        Task<bool> Register(Register register);

        //login user
        Task<string> Login(UserCredential userCredential);

        //authenticate
        string Authenticate(string username, string password, string role = "User");

        //update password
        IdentityResult UpdatePassword(IdentityUser user, string currentPassword, string newPassword);

        //update email
        IdentityResult UpdateEmail(IdentityUser user, string newMail, string token);

        //add role to user
        Task<string> AddRoleToUser(string role, string userName);

        //remove role from user
        Task<string> RemoveRoleFromUser(string role, string userName);
    }
}
