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
    public class GetRoles : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly Mock<RoleManager<IdentityRole>> roleManagerMock;
        private readonly Mock<UserManager<IdentityUser>> userManagerMock;

        public GetRoles()
        {
            IdentityUser identityUser = new()
            {
                Id = "125",
                UserName = "Juan",
                PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                Email = "new.juan@newJuan.com",
                NormalizedEmail = "NEW.JUAN@NEWJUAN.COM",
                NormalizedUserName = "NEWJUAN",
                EmailConfirmed = true
            };

            List<string>? roles = new() { "User" };

            userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);

            userManagerMock.Setup(x => x.GetRolesAsync(It.IsAny<IdentityUser>())).ReturnsAsync(roles);

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();


            userService = new UserService(context, userManagerMock.Object, roleManagerMock.Object);
        }

        [Fact]
        public void Get_Should_ReturnListAsync()
        {
            //arrange
            IdentityUser identityUser = new()
            {
                Id = "125",
                UserName = "Juan",
                PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                Email = "new.juan@newJuan.com",
                NormalizedEmail = "NEW.JUAN@NEWJUAN.COM",
                NormalizedUserName = "NEWJUAN",
                EmailConfirmed = true
            };

            //act
            IList <string> roleList = userService.GetRoles(identityUser);

            //assert
            Assert.True(roleList.Any());
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
