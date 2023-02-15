using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using TestSupport.EfHelpers;
using Xunit;
namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Update
    {
        Pokemon pokemon;
        Pokemon emptyPokemon;
        Pokemon? nullPokemon;

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
        }

        [Fact]
        public void Update_Should_ChangePokemon()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            Pokemon updatedPokemon = pokemonService2.Update(pokemon);

            //assert
            Assert.True(updatedPokemon.Id == pokemon.Id);
            Assert.True(updatedPokemon.Name == pokemon.Name);
        }

        [Fact]
        public void Update_Should_ThrowNullReferenceException_WhenUpdatingPokemonWithoutInfo()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            Pokemon updatedPokemon = pokemonService2.Update(emptyPokemon);

            //assert
            Assert.True(updatedPokemon.Id == 0);
            Assert.True(updatedPokemon.Name == null);
        }

        [Fact]
        public void Update_Should_ThrowNullReferenceException_WhenUpdatingNullPokemon()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act & assert
            Assert.Throws<NullReferenceException>(() => pokemonService2.Update(nullPokemon));
        }
    }
}