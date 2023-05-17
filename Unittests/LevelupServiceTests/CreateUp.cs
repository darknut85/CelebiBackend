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
        readonly PokemonService pokemonService;
        readonly MoveService moveService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public CreateUp()
        {
            levelup = new LevelupMove() { };
            existingLevelup = new LevelupMove() { Id = 200, Level = 100, PokemonId = 1, MoveId = 1 };
            emptyLevelup = new LevelupMove();
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();

            moveService = new MoveService(context);
            pokemonService = new PokemonService(context);
            levelupService = new LevelupService(context, moveService, pokemonService);

        }

        [Fact]
        public void Create_Should_MakeLevelupMove()
        {
            //arrange

            //act
            LevelupMove newLevelup = levelupService.Create(levelup);

            //assert
            Assert.True(newLevelup.Id == levelup.Id);
            Assert.True(newLevelup.PokemonId == levelup.PokemonId);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0)]
        [InlineData(155, 3, 3, 3)]

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
        public void Create_Should_MakeLevelupMoveWithoutInfo(int MoveId, int PokemonId)
        {
            //arrange
            emptyLevelup.PokemonId = PokemonId;
            emptyLevelup.MoveId = MoveId;

            //act
            LevelupMove newLevelup = levelupService.Create(emptyLevelup);

            //assert
            Assert.True(newLevelup.Id == 0);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
