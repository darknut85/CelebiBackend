using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Update
    {
        Pokemon pokemon;
        Pokemon emptyPokemon;
        Pokemon? nullPokemon;
        PokemonService pokemonService;
        DbContextOptions<DataContext> options;

        public Update() 
        {
            pokemon = new Pokemon()
            {
                Id = 5,
                Name = "Chikorita",
                DexEntry = 5,
                Type1 = "Grass",
                Type2 = "",
                Height = 4,
                Weight = 1,
                Classification = "???",
                PokedexEntry = "..."
            };

            emptyPokemon = new Pokemon();
            nullPokemon = null;
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            DataContext context = new(options);
            context.DefaultSetup();
            pokemonService = new PokemonService(context);
        }

        [Fact]
        public void Update_Should_ChangePokemon()
        {
            //arrange

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

            //act
            Pokemon updatedPokemon = pokemonService.Update(emptyPokemon);

            //assert
            Assert.True(updatedPokemon.Id == 0);
            Assert.True(updatedPokemon.Name == null);
        }

        [Fact]
        public void Update_Should_ThrowNullReferenceException_WhenUpdatingNullPokemon()
        {
            //arrange

            //act & assert
            Assert.Throws<NullReferenceException>(() => pokemonService.Update(nullPokemon));
        }
    }
}