using Interfaces;
using Microsoft.AspNetCore.Identity;
using Migrations;
using System.Diagnostics;

namespace Services
{
    public class UserService : IUserService
    {
        DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(DataContext dataContext, UserManager<IdentityUser> userManager) 
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public IdentityUser getUser(string username)
        {
            IdentityUser identityUser = _dataContext.Set<IdentityUser>().FirstOrDefault(x => x.UserName == username);
            if (identityUser != null)
            {
                return identityUser;
            }
            return null;
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

            if (user == null)
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
            var roles = _userManager.GetRolesAsync(user);
            roles.Wait();
            var result = roles.Result;
            return result;
        }
    }
}
