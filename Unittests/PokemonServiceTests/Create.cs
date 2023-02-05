using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Create
    {
        Pokemon pokemon;
        Pokemon existingPokemon;
        Pokemon emptyPokemon;
        Pokemon? nullPokemon;

        public Create() 
        { 
            pokemon = new Pokemon() { Id = 150, Name = "Mewtwo", DexEntry = 150, Type1 = "Psychic", Type2 = "", Height = 2, Weight = 2, Classification = "???", PokedexEntry = "..." };
            existingPokemon = new Pokemon() { Id = 1, Name = "Bulbasaur" };
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
        public void Create_ShouldNot_MakePokemon_IfPokemonExists()
        {
            //arrange
            PokemonService pokemonService = new();

            //act
            Pokemon newPokemon = pokemonService.Create(existingPokemon);

            //assert
            Assert.True(newPokemon.Id == 0);
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