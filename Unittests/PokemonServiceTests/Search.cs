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
    public class Search
    {
        [Theory]
        [InlineData("Bulbasaur")]
        [InlineData("Fire")]
        [InlineData("Poison")]
        [InlineData("absorbing")]
        public void Search_Should_ReturnList(string text)
        {
            //arranger
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            List<Pokemon> pokemonList = pokemonService2.Search(text);

            //assert
            Assert.True(pokemonList.Any());
        }

        [Fact]
        public void Search_Should_ReturnEmptyList() 
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            List<Pokemon> pokemonList = pokemonService2.Search("psychic");

            //assert
            Assert.False(pokemonList.Any());
        }

        [Fact]
        public void Search_Should_ReturnMultipleEntries()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            List<Pokemon> pokemonList = pokemonService2.Search("saur");

            //assert
            Assert.True(pokemonList.Count() == 3);
        }

        [Fact]
        public void Search_Should_ReturnZeroEntries()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act & assert
            var a = pokemonService2.Search(null);

            Assert.True(a.Count == 0);
        }
    }
}