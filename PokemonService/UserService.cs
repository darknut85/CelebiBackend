using Interfaces;
using Microsoft.AspNetCore.Identity;
using Migrations;
using System.Diagnostics;

namespace Services
{
    public class UserService : IUserService
    {
        DataContext _dataContext;
        public UserService(DataContext dataContext) 
        {
            _dataContext = dataContext;
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

        public List<IdentityUser> getUsers()
        {
            var data = _dataContext.Set<IdentityRole>().ToList();
            foreach (var item in data)
            {
                Debug.WriteLine(item);
            }
            Debug.WriteLine("Debug works");

            return _dataContext.Set<IdentityUser>().OrderBy(x => x.Id).ToList();
        }
    }
}
