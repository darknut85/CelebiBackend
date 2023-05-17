using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.LevelupServiceTests
{
    [ExcludeFromCodeCoverage]
    public class DeleteUp : IDisposable
    {
        readonly LevelupService levelupService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public DeleteUp()
        {

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            levelupService = new LevelupService(context);
        }
        [Fact]
        public void Delete_Should_DeleteLevelupMove()
        {
            //arrange

            //act
            Delete deleted = levelupService.Delete(1);

            //assert
            Assert.True(deleted.Deleted);
        }

        [Fact]
        public void Delete_Should_NotDeleteLevelupMove()
        {
            //arrange

            //act
            Delete deleted = levelupService.Delete(999);

            //assert
            Assert.False(deleted.Deleted);
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
