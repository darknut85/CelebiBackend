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
    public class GetId: IDisposable
    {
        readonly PokemonService pokemonService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public GetId()
        {

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            pokemonService = new PokemonService(context);
        }

        [Fact]
        public void GetId_Should_ReturnPokemon()
        {
            //arrange

            //act
            Pokemon pokemon = pokemonService.Get(1);

            //assert
            Assert.True(pokemon.Id == 1);
            Assert.True(pokemon.Name == "Bulbasaur");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void GetId_Should_ReturnNoPokemon(int id)
        {
            //arrange

            //act
            Pokemon pokemon = pokemonService.Get(id);

            //assert
            Assert.True(pokemon.Id == 0);
            Assert.True(pokemon.Name == "");
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}