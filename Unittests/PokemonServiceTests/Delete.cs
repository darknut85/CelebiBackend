using Microsoft.EntityFrameworkCore;
using Migrations;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;
using Objects;

namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Deletes
    {
        readonly PokemonService pokemonService;
        readonly DbContextOptions<DataContext> options;

        public Deletes()
        {

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            DataContext context = new(options);
            context.DefaultSetup();
            pokemonService = new PokemonService(context);
        }
        [Fact]
        public void Delete_Should_DeletePokemon()
        {
            //arrange

            //act
            Delete deleted = pokemonService.Delete(5);

            //assert
            Assert.True(deleted.Deleted);
        }

        [Fact]
        public void Delete_Should_NotDeletePokemon()
        {
            //arrange

            //act
            Delete deleted = pokemonService.Delete(999);

            //assert
            Assert.False(deleted.Deleted);
        }
    }
}