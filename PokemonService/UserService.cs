using Interfaces;
using Microsoft.AspNetCore.Identity;
using Migrations;
using System.Diagnostics;
using Objects;
using Celebi.Api.models;

namespace Services
{
    public class UserService : IUserService
    {
        private List<UserRole> _roles;
        DataContext _dataContext;
        public UserService(DataContext dataContext) 
        {
            _dataContext = dataContext;
            _roles= new List<UserRole>();
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
            var data = _dataContext.Set<IdentityRole>().ToList();
            foreach (var item in data)
            {
                Debug.WriteLine(item);
            }
            Debug.WriteLine("Debug works");

            return _dataContext.Set<IdentityUser>().OrderBy(x => x.Id).ToList();
        }

        public bool HasRole(string role)
        {
            return _roles.Where(x => x.Name== role).ToList().Count > 0;
        }
    }
}
