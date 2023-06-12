using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;
using Moq;

namespace Unittests.UserServiceTests
{
    [ExcludeFromCodeCoverage]
    public class GetUser : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly Mock<UserManager<IdentityUser>> userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> roleManagerMock;

        public GetUser()
        {
            userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
            
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            userService = new UserService(context, userManagerMock.Object, roleManagerMock.Object);
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
            GC.SuppressFinalize(this);
        }
    }
}
