using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Moq;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.UserServiceTests
{
    [ExcludeFromCodeCoverage]
    public class GetUsers : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly Mock<RoleManager<IdentityRole>> roleManagerMock;
        private readonly Mock<UserManager<IdentityUser>> userManagerMock;
        public GetUsers()
        {
            userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            userService = new UserService(context,userManagerMock.Object, roleManagerMock.Object);
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
            GC.SuppressFinalize(this);
        }
    }
}
