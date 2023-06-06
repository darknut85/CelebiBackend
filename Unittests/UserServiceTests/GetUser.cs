using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace Unittests.UserServiceTests
{
    [ExcludeFromCodeCoverage]
    public class GetUser : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public GetUser()
        {
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            userService = new UserService(context, _userManager, _roleManager, _configuration);
        }

        [Fact]
        public void GetId_Should_ReturnUser()
        {
            //arrange

            //act
            IdentityUser? user = userService.GetUser("Juan");

            //assert
            Assert.True(user.UserName == "Juan");
        }

        [Fact]
        public void GetId_Should_ReturnNoUser()
        {
            //arrange

            //act
            IdentityUser? user = userService.GetUser("Jan");

            //assert
            Assert.True(user.UserName == "");
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
