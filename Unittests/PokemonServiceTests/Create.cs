using Interfaces;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Moq;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using TestSupport.EfHelpers;
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
        PokemonService pokemonService;
        DataContext context;


        public Create() 
        { 
            pokemon = new Pokemon() {Name = "Chikorita", DexEntry = 152, Type1 = "Grass", Type2 = "", Height = 3, Weight = 3, Classification = "???", PokedexEntry = "..." };
            existingPokemon = new Pokemon() { Id = 150, Name = "Mewtwo" };
            emptyPokemon = new Pokemon();
            nullPokemon = null;
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            pokemonService = new PokemonService(context);

        }

        [Fact]
        public void Create_Should_MakePokemon()
        {
            //arrange
            PokemonService pokemonService = new(context);

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
            PokemonService pokemonService = new(context);

            //act
            Pokemon newPokemon = pokemonService.Create(existingPokemon);

            //assert
            Assert.True(newPokemon.Id == 0);
        }

        [Fact]
        public void Create_Should_MakePokemonWithoutInfo()
        {
            //arrange
            PokemonService pokemonService = new(context);

            //act
            Pokemon newPokemon = pokemonService.Create(emptyPokemon);

            //assert
            Assert.Null(newPokemon.Name = null);
        }

        [Fact]
        public void Create_Should_ThrowNullReferenceException()
        {
            //arrange
            PokemonService pokemonService = new(context);

            //act & assert
            Assert.Throws<NullReferenceException>(() => pokemonService.Create(nullPokemon));
        }
    }
}