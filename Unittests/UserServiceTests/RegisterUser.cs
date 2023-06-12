using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;
using Moq;
using Objects;

namespace Unittests.UserServiceTests
{
    [ExcludeFromCodeCoverage]
    public class RegisterUser : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly Mock<RoleManager<IdentityRole>> roleManagerMock;
        private readonly Mock<UserManager<IdentityUser>> userManagerMock;
        private readonly IdentityUser identityUser;
        private readonly IdentityRole identityRole;
        private readonly Register register;
        private readonly IdentityUser emptyId;
        private readonly IdentityRole emptyRole;

        public RegisterUser()
        {
            identityUser = new IdentityUser()
            {
                Id = "125",
                UserName = "Juan",
                PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                Email = "new.juan@newJuan.com",
                NormalizedEmail = "NEW.JUAN@NEWJUAN.COM",
                NormalizedUserName = "NEWJUAN",
                EmailConfirmed = true
            };

            identityRole = new IdentityRole()
            {
                Id = "457",
                Name = "Test",
                NormalizedName = "TEST"

            };

            register = new Register()
            {
                Email = "",
                Password = "",
                Username = "",
                Role = ""
            };

            List<string>? roles = new() { "User" };

            userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);

            roleManagerMock.Setup(r => r.RoleExistsAsync("Admin")).ReturnsAsync(true);
            roleManagerMock.Setup(r => r.RoleExistsAsync("User")).ReturnsAsync(true);
            roleManagerMock.Setup(r => r.CreateAsync(new IdentityRole("Admin")));
            roleManagerMock.Setup(r => r.CreateAsync(new IdentityRole("User")));

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();


            userService = new UserService(context, userManagerMock.Object, roleManagerMock.Object);
        }

        //make new user
        [Fact]
        public async Task Get_Should_MakeNewUser()
        {
            //arrange
            userManagerMock.Setup(r => r.CreateAsync(identityUser, "")).ReturnsAsync(new IdentityResult() { });
            userManagerMock.Setup(r => r.AddToRoleAsync(identityUser, "")).ReturnsAsync(new IdentityResult() {});
            userManagerMock.SetupSequence( r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(emptyId)).Returns(Task.FromResult(identityUser));
            roleManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(identityRole));

            //act
            bool isRegistered = await userService.Register(register);

            //assert
            Assert.True(isRegistered);
        }

        [Fact]
        public async Task Get_Should_NotCreateUser_IfUserExists()
        {
            //arrange
            userManagerMock.SetupSequence(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(identityUser));

            //act
            bool isRegistered = await userService.Register(register);

            //assert
            Assert.False(isRegistered);
        }

        [Fact]
        public async Task Get_Should_NotCreateUser_IfRoleDoesNotExist()
        {
            //arrange
            userManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(emptyId));
            roleManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(emptyRole));

            //act
            bool isRegistered = await userService.Register(register);

            //assert
            Assert.False(isRegistered);
        }


        public void Dispose()
        {
            context.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}