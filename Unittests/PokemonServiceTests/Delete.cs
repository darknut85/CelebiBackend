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
        [Fact]
        public void Delete_Should_DeletePokemon()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            bool deleted = pokemonService2.Delete(5);

            //assert
            Assert.True(deleted);
        }

        [Fact]
        public void Delete_Should_NotDeletePokemon()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            bool deleted = pokemonService2.Delete(999);

            //assert
            Assert.False(deleted);
        }
    }
}