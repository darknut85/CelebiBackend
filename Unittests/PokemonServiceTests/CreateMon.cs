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
    public class CreateMon : IDisposable
    {
        readonly Pokemon pokemon;
        readonly Pokemon existingPokemon;
        readonly Pokemon emptyPokemon;
        readonly PokemonService pokemonService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;


        public CreateMon() 
        {
            pokemon = new Pokemon() 
            {
                Name = "Chikorita", DexEntry = 152, 
                Type1 = "Grass", Type2 = "", 
                Height = 3, Weight = 3, 
                Classification = "???", PokedexEntry = "...", 
                HP = 1, ATK = 1, DEF = 1, SPATK = 1, SPDEF = 1, SPD = 1, 
                HPEV = 1, ATKEV = 1, DEFEV = 1, SPATKEV = 1, SPDEFEV = 1, SPDEV = 1, 
                GrowthRate = 1
            };
            existingPokemon = new Pokemon() { Id = 150, Name = "Mewtwo" };
            emptyPokemon = new Pokemon();
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            pokemonService = new PokemonService(context);

        }

        [Fact]
        public void Create_Should_MakePokemon()
        {
            //arrange

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

            //act
            Pokemon newPokemon = pokemonService.Create(existingPokemon);

            //assert
            Assert.True(newPokemon.Id == 0);
        }

        [Fact]
        public void Create_Should_MakePokemonWithoutInfo()
        {
            //arrange

            //act
            Pokemon newPokemon = pokemonService.Create(emptyPokemon);

            //assert
            Assert.Equal("", newPokemon.Name);
            Assert.Equal(0, newPokemon.DexEntry);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}