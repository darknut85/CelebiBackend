using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Delete
    {
        [Fact]
        public void Delete_Should_DeletePokemon()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            bool deleted = pokemonService.Delete(1);

            //assert
            Assert.True(deleted);
        }

        [Fact]
        public void Delete_Should_NotDeletePokemon()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            bool deleted = pokemonService.Delete(999);

            //assert
            Assert.False(deleted);
        }
    }
}