using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace Unittests.UserServiceTests
{
    [ExcludeFromCodeCoverage]
    public class GetUsers : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public GetUsers()
        {
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            userService = new UserService(context,_userManager, _roleManager, _configuration);
        }

        [Fact]
        public void Get_Should_ReturnList()
        {
            //arrange

            //act
            List<IdentityUser> userList = userService.GetUsers();

            //assert
            Assert.True(userList.Any());
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
