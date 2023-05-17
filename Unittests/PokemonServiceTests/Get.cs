using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Get : IDisposable
    {
        readonly PokemonService pokemonService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;
        public Get()
        {
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            pokemonService = new PokemonService(context);
        }

        [Fact]
        public void Get_Should_ReturnList()
        {
            //arrange

            //act
            List<Pokemon> pokemonList = pokemonService.Get();

            //assert
            Assert.True(pokemonList.Any());
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}