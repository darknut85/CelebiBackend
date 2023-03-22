using Interfaces;
using Microsoft.AspNetCore.Identity;
using Migrations;

namespace Services
{
    public class UserService : IUserService
    {
        DataContext _dataContext;
        public UserService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public IdentityUser getUser(string username, string password)
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
            return _dataContext.Set<IdentityUser>().OrderBy(x => x.Id).ToList();
        }
    }
}
