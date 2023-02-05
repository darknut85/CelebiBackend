using Objects;
using Services;
using Xunit;
namespace Unittests.PokemonServiceTests
{
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
        public void Create_Should_NotDeletePokemon()
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