using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Get
    {
        [Fact]
        public void Get_Should_ReturnList()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            List<Pokemon> pokemonList = pokemonService.Get();

            //assert
            Assert.True(pokemonList.Any());
        }
    }
}