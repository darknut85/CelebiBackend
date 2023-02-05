using Objects;
using Services;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    public class Create
    {
        Pokemon pokemon;
        Pokemon emptyPokemon;
        Pokemon? nullPokemon;

        public Create() 
        { 
            pokemon = new Pokemon() { Id = 150, Name = "Mewtwo", DexEntry = 150, Type1 = "Psychic", Type2 = "", Height = 2, Weight = 2, Classification = "???", PokedexEntry = "..." };
            emptyPokemon = new Pokemon();
            nullPokemon = null;
        }

        [Fact]
        public void Create_Should_MakePokemon()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            Pokemon newPokemon = pokemonService.Create(pokemon);

            //assert
            Assert.True(newPokemon.Id == pokemon.Id);
            Assert.True(newPokemon.Name == pokemon.Name);
        }

        [Fact]
        public void Create_Should_MakePokemonWithoutInfo()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            Pokemon newPokemon = pokemonService.Create(emptyPokemon);

            //assert
            Assert.Null(newPokemon.Name = null);
        }

        [Fact]
        public void Create_Should_ThrowNullReferenceException()
        {
            //arrange
            PokemonService pokemonService = new();

            //act & assert
            Assert.Throws<NullReferenceException>(() => pokemonService.Create(nullPokemon));
        }
    }
}