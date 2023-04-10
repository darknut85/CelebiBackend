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
    public class Search
    {
        readonly PokemonService pokemonService;
        readonly DbContextOptions<DataContext> options;

        public Search()
        {
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            DataContext context = new(options);
            context.DefaultSetup();
            pokemonService = new PokemonService(context);
        }

        [Theory]
        [InlineData("Bulbasaur")]
        [InlineData("Fire")]
        [InlineData("Poison")]
        [InlineData("absorbing")]
        public void Search_Should_ReturnList(string text)
        {
            //arranger

            //act
            List<Pokemon> pokemonList = pokemonService.Search(text);

            //assert
            Assert.True(pokemonList.Any());
        }

        [Fact]
        public void Search_Should_ReturnEmptyList() 
        {
            //arrange

            //act
            List<Pokemon> pokemonList = pokemonService.Search("psychic");

            //assert
            Assert.False(pokemonList.Any());
        }

        [Fact]
        public void Search_Should_ReturnMultipleEntries()
        {
            //arrange

            //act
            List<Pokemon> pokemonList = pokemonService.Search("saur");

            //assert
            Assert.True(pokemonList.Count == 3);
        }

        [Fact]
        public void Search_Should_ReturnZeroEntries()
        {
            //arrange

            //act & assert
            List<Pokemon>? a = pokemonService.Search("random text that does not exist");

            Assert.True(a.Count == 0);
        }
    }
}