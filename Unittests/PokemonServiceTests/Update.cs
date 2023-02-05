using Objects;
using Services;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    public class Update
    {
        Pokemon pokemon;
        Pokemon emptyPokemon;
        Pokemon? nullPokemon;

        public Update() 
        {
            pokemon = new Pokemon()
            {
                Id = 1,
                Name = "Squirtle",
                DexEntry = 7,
                Classification = "Turtle Pokemon",
                Height = 0.7,
                Weight = 6.9,
                Type1 = "Water",
                Type2 = "",
                PokedexEntry = "Water guns. Has a thick shell"
            };

            emptyPokemon = new Pokemon();
            nullPokemon = null;
        }

        [Fact]
        public void Update_Should_ChangePokemon()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            Pokemon updatedPokemon = pokemonService.Update(pokemon);

            //assert
            Assert.True(updatedPokemon.Id == pokemon.Id);
            Assert.True(updatedPokemon.Name == pokemon.Name);
        }

        [Fact]
        public void Update_Should_ThrowNullReferenceException_WhenUpdatingPokemonWithoutInfo()
        {
            //arrange
            PokemonService pokemonService = new();

            //act & assert
            Assert.Throws<NullReferenceException>(() => pokemonService.Update(emptyPokemon));
        }

        [Fact]
        public void Update_Should_ThrowNullReferenceException_WhenUpdatingNullPokemon()
        {
            //arrange
            PokemonService pokemonService = new();

            //act & assert
            Assert.Throws<NullReferenceException>(() => pokemonService.Update(nullPokemon));
        }
    }
}