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
    public class CreateUp : IDisposable
    {
        readonly LevelupMove levelup;
        readonly LevelupMove existingLevelup;
        readonly LevelupMove emptyLevelup;
        readonly LevelupService levelupService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public CreateUp()
        {
            levelup = new LevelupMove() { Level = 44, PokemonId = 1, MoveId = 1 };
            existingLevelup = new LevelupMove() { Id = 200, Level = 100, PokemonId = 1, MoveId = 1 };
            emptyLevelup = new LevelupMove();
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            levelupService = new LevelupService(context);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(130)]
        public void Create_Should_MakeLevelupMove(int id)
        {
            //arrange
            levelup.Id = id;

            //act
            LevelupMove newLevelup = levelupService.Create(levelup);

            //assert
            Assert.True(newLevelup.Id == levelup.Id);
            Assert.True(newLevelup.PokemonId == levelup.PokemonId);
        }

        [Theory]
        [InlineData(1, 0, 0, 0)]
        [InlineData(155, 3, 3, 3)]
        [InlineData(200, 1, 2, 3)]

        public void Create_ShouldNot_MakeLevelupMove_IfLevelupMoveExists(int id, int pId, int mId, int lvl)
        {
            //arrange
            existingLevelup.Id = id;
            existingLevelup.PokemonId = pId;
            existingLevelup.MoveId = mId;
            existingLevelup.Level = lvl;

            //act
            LevelupMove newLevelup = levelupService.Create(existingLevelup);

            //assert
            Assert.True(newLevelup.Id == 0);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(150, 0)]
        [InlineData(0, 150)]
        public void Create_ShouldNot_MakeLevelupMoveWithoutInfo(int MoveId, int PokemonId)
        {
            //arrange
            emptyLevelup.PokemonId = PokemonId;
            emptyLevelup.MoveId = MoveId;

            //act
            LevelupMove newLevelup = levelupService.Create(emptyLevelup);

            //assert
            Assert.True(newLevelup.Id == 0);
            Assert.True(newLevelup.MoveId == 0);
            Assert.True(newLevelup.PokemonId == 0);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
