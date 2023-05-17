using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System.Diagnostics.CodeAnalysis;
using Test.Helpers;
using Xunit;

namespace Unittests.MoveServiceTests
{
    [ExcludeFromCodeCoverage]
    public class SearchMove :IDisposable
    {
        readonly MoveService moveService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public SearchMove()
        {
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);
        }

        [Theory]
        [InlineData("Tackle")]
        [InlineData("Normal")]
        [InlineData("claws")]
        public void Search_Should_ReturnList(string text)
        {
            //arranger

            //act
            List<Move> moveList = moveService.Search(text);

            //assert
            Assert.True(moveList.Any());
        }

        [Fact]
        public void Search_Should_ReturnEmptyList()
        {
            //arrange

            //act
            List<Move> moveList = moveService.Search("darkest hour");

            //assert
            Assert.False(moveList.Any());
        }

        [Fact]
        public void Search_Should_ReturnMultipleEntries()
        {
            //arrange

            //act
            List<Move> moveList = moveService.Search("Normal");

            //assert
            Assert.True(moveList.Count == 4);
        }

        [Fact]
        public void Search_Should_ReturnZeroEntries()
        {
            //arrange

            //act & assert
            List<Move>? a = moveService.Search("random text that does not exist");

            Assert.True(a.Count == 0);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
