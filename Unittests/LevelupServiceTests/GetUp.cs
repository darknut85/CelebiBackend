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
    public class GetUp : IDisposable
    {
        readonly LevelupService levelupService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;
        readonly PokemonService pokemonService;
        readonly MoveService moveService;
        public GetUp()
        {
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);
            pokemonService = new PokemonService(context);
            levelupService = new LevelupService(context, moveService, pokemonService);
        }

        [Fact]
        public void Get_Should_ReturnList()
        {
            //arrange

            //act
            List<LevelupMove> moveList = levelupService.Get();

            //assert
            Assert.True(moveList.Any());
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
