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
    public class GetIdUp : IDisposable
    {
        readonly LevelupService levelupService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public GetIdUp()
        {

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            levelupService = new LevelupService(context);
        }

        [Fact]
        public void GetId_Should_ReturnLevelupMove()
        {
            //arrange

            //act
            LevelupMove levelup = levelupService.Get(200);

            //assert
            Assert.True(levelup.Id == 200);
            Assert.True(levelup.Level == 2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void GetId_Should_ReturnNoLevelupMove(int id)
        {
            //arrange

            //act
            LevelupMove move = levelupService.Get(id);

            //assert
            Assert.True(move.Id == 0);
            Assert.True(move.Level == 0);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
