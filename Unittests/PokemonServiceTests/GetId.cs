using Objects;
using Services;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    public class GetId
    {
        [Fact]
        public void GetId_Should_ReturnPokemon()
        {
            //arrange
            PokemonService pokemonService = new();

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
            PokemonService pokemonService = new();

            //act
            Pokemon pokemon = pokemonService.Get(id);

            //assert
            Assert.True(pokemon.Id == 0);
            Assert.True(pokemon.Name == null);
        }
    }
}