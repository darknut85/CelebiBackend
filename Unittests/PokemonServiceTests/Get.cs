using Objects;
using Services;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    public class Get
    {
        [Fact]
        public void Get_Should_ReturnList()
        {
            //arranger
            PokemonService pokemonService = new();

            //act
            List<Pokemon> pokemonList = pokemonService.Get();

            //assert
            Assert.True(pokemonList.Any());
        }
    }
}