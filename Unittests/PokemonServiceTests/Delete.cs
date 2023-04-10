using Microsoft.EntityFrameworkCore;
using Migrations;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.PokemonServiceTests
{
    [ExcludeFromCodeCoverage]
    public class Delete
    {
        readonly PokemonService pokemonService;
        readonly DbContextOptions<DataContext> options;

        public Delete()
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
            bool deleted = pokemonService.Delete(5);

            //assert
            Assert.True(deleted);
        }

        [Fact]
        public void Delete_Should_NotDeletePokemon()
        {
            //arrange

            //act
            bool deleted = pokemonService.Delete(999);

            //assert
            Assert.False(deleted);
        }
    }
}