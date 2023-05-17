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
    public class UpdateUp : IDisposable
    {
        readonly LevelupMove levelup;
        readonly LevelupMove emptyLevelup;
        readonly DbContextOptions<DataContext> options;
        readonly PokemonService pokemonService;
        readonly LevelupService levelupService;
        readonly MoveService moveService;
        DataContext context;

        public UpdateUp()
        {
            levelup = new LevelupMove()
            {
                Id = 1,
                PokemonId = 1,
                MoveId = 1,
                Level = 1
            };

            emptyLevelup = new LevelupMove();
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);
            pokemonService = new PokemonService(context);
            levelupService = new LevelupService(context, moveService, pokemonService);
        }

        [Fact]
        public void Update_Should_ChangeMove()
        {
            //arrange

            //act
            LevelupMove updatedLevelup = levelupService.Update(levelup);

            //assert
            Assert.True(updatedLevelup.Id == levelup.Id);
            Assert.True(updatedLevelup.PokemonId == levelup.PokemonId);
        }

        [Fact]
        public void Update_Should_ReturnNewMove_WhenUpdatingMoveWithoutInfo()
        {
            //arrange

            //act
            LevelupMove updatedLevelup = levelupService.Update(emptyLevelup);

            //assert
            Assert.True(updatedLevelup.Id == 0);
            Assert.True(updatedLevelup.MoveId == 0);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
