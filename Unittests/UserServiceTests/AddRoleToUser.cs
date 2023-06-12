using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class AddRoleToUser : IDisposable
    {
        readonly UserService userService;
        readonly DbContextOptions<DataContext> options;
        private readonly DataContext context;
        private readonly Mock<RoleManager<IdentityRole>> roleManagerMock;
        private readonly Mock<UserManager<IdentityUser>> userManagerMock;
        private readonly IdentityUser identityUser;
        public AddRoleToUser() 
        {
            userManagerMock = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();

            userService = new UserService(context, userManagerMock.Object, roleManagerMock.Object);

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
        }

        [Fact]
        public async Task Get_Should_AddRole()
        {
            //arrange
            UserCredential userCredential = new() { Id = 1, Password = "", UserName = "" };
            IList<string> role = new List<string>() { "Admin" };
            IQueryable<IdentityRole> roleQueries = new List<IdentityRole>() {
                new IdentityRole()
                {
                    Id = "457",
                    Name = "User",
                    NormalizedName = "USER"

                }
            }.AsQueryable();
            userManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(identityUser));
            userManagerMock.Setup(r => r.GetRolesAsync(identityUser)).Returns(Task.FromResult(role));
            roleManagerMock.Setup(r => r.Roles).Returns(roleQueries);
            userManagerMock.Setup(r => r.AddToRoleAsync(identityUser, "")).ReturnsAsync(new IdentityResult() { });


            //act
            string isAdded = await userService.AddRoleToUser("User", "Juan");

            //assert
            Assert.True(isAdded == "The role has been added to the user");
        }

        [Fact]
        public async Task Get_Should_NotAddRole_WhenUserDoesNotExist()
        {
            //arrange
            UserCredential userCredential = new() { Id = 1, Password = "", UserName = "" };
            IList<string> role = new List<string>() { "Admin" };
            IdentityUser noName = new() { UserName = ""};
            userManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(noName));

            //act
            string isAdded = await userService.AddRoleToUser("User", "Juan");

            //assert
            Assert.True(isAdded == "The user does not exist");
        }

        [Fact]
        public async Task Get_Should_NotAddRole_WhenRoleDoesNotExist()
        {
            //arrange
            UserCredential userCredential = new() { Id = 1, Password = "", UserName = "" };
            IList<string> role = new List<string>() { "Admin" };
            IQueryable<IdentityRole> roleQueries = new List<IdentityRole>() {
            }.AsQueryable();
            userManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(identityUser));
            userManagerMock.Setup(r => r.GetRolesAsync(identityUser)).Returns(Task.FromResult(role));
            roleManagerMock.Setup(r => r.Roles).Returns(roleQueries);

            //act
            string isAdded = await userService.AddRoleToUser("User", "Juan");

            //assert
            Assert.True(isAdded == "The role does not exist");
        }

        [Fact]
        public async Task Get_Should_NotAddRole_WhenUserAlreadyHasRole()
        {
            //arrange
            UserCredential userCredential = new() { Id = 1, Password = "", UserName = "" };
            IList<string> role = new List<string>() { "Admin" };
            IQueryable<IdentityRole> roleQueries = new List<IdentityRole>() {
                new IdentityRole()
                {
                    Id ="997",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            }.AsQueryable();
            userManagerMock.Setup(r => r.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(identityUser));
            userManagerMock.Setup(r => r.GetRolesAsync(identityUser)).Returns(Task.FromResult(role));
            roleManagerMock.Setup(r => r.Roles).Returns(roleQueries);
            userManagerMock.Setup(r => r.AddToRoleAsync(identityUser, "")).ReturnsAsync(new IdentityResult() { });


            //act
            string isAdded = await userService.AddRoleToUser("Admin", "Juan");

            //assert
            Assert.True(isAdded == "The user already as the role");
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
