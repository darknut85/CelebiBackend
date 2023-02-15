using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using TestSupport.EfHelpers;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class GetId
    {
        [Fact]
        public void GetId_Should_ReturnPokemon()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            Pokemon pokemon = pokemonService2.Get(1);

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
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            Pokemon pokemon = pokemonService2.Get(id);

            //assert
            Assert.True(pokemon.Id == 0);
            Assert.True(pokemon.Name == null);
        }
    }
}