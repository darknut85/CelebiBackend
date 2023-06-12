using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Migrations;
using Moq;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.UserServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Login : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly IConfiguration _configuration;
        private readonly Mock<RoleManager<IdentityRole>> roleManagerMock;
        private readonly Mock<UserManager<IdentityUser>> userManagerMock;
        private readonly IdentityUser identityUser;

        public Login() 
        {
            userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();

            userService = new UserService(context, userManagerMock.Object, roleManagerMock.Object, _configuration);

            identityUser = new IdentityUser()
            {
                Id = "125",
                UserName = "",
                PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                Email = "new.juan@newJuan.com",
                NormalizedEmail = "NEW.JUAN@NEWJUAN.COM",
                NormalizedUserName = "NEWJUAN",
                EmailConfirmed = true
            };
        }

        [Fact]
        public async Task Get_Should_Login()
        {
            //arrange
            UserCredential userCredential = new UserCredential() { Id = 1, Password = "", UserName = ""};
            IList<string> role = new List<string>() {"User", "Admin" };
            userManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(identityUser));
            userManagerMock.Setup(r => r.GetRolesAsync(identityUser)).Returns(Task.FromResult(role));
            


            //act
            string isRegistered = await userService.Login(userCredential);

            //assert
            Assert.True(isRegistered == "");
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
