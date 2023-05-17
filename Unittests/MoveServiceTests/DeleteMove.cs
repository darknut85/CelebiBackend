using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.MoveServiceTests
{
    [ExcludeFromCodeCoverage]
    public class DeleteMove :IDisposable
    {
        readonly MoveService moveService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public DeleteMove()
        {

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);
        }
        [Fact]
        public void Delete_Should_DeleteMove()
        {
            //arrange

            //act
            Delete deleted = moveService.Delete(2);

            //assert
            Assert.True(deleted.Deleted);
        }

        [Fact]
        public void Delete_Should_NotDeleteMove()
        {
            //arrange

            //act
            Delete deleted = moveService.Delete(999);

            //assert
            Assert.False(deleted.Deleted);
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
