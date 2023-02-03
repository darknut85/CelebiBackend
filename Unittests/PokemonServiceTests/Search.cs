using Objects;
using Services;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace Unittests.PokemonServiceTests
{
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
            PokemonService pokemonService = new();

            //act
            List<Pokemon> pokemonList = pokemonService.Search(text);

            //assert
            Assert.True(pokemonList.Any());
        }

        [Fact]
        public void Search_Should_ReturnEmptyList() 
        { 
            //arrange
            PokemonService pokemonService = new();

            //act
            List<Pokemon> pokemonList = pokemonService.Search("psychic");

            //assert
            Assert.False(pokemonList.Any());
        }

        [Fact]
        public void Search_Should_ReturnMultipleEntries()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            List<Pokemon> pokemonList = pokemonService.Search("saur");

            //assert
            Assert.True(pokemonList.Count() == 3);
        }
    }
}