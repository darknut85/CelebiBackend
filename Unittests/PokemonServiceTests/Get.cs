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
    public class Get
    {
        [Fact]
        public void Get_Should_ReturnList()
        {
            //arrange
            DbContextOptions<DataContext> options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            //this.CreateUniqueClassOptions<DataContext>();
            using DataContext context = new(options);
            context.DefaultSetup();
            PokemonService pokemonService2 = new(context);

            //act
            List<Pokemon> pokemonList = pokemonService2.Get();

            //assert
            Assert.True(pokemonList.Any());
        }
    }
}