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
    public class GetMove : IDisposable
    {
        readonly MoveService moveService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;
        public GetMove()
        {
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);
        }

        [Fact]
        public void Get_Should_ReturnList()
        {
            //arrange

            //act
            List<Move> moveList = moveService.Get();

            //assert
            Assert.True(moveList.Any());
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
