using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Helpers;
using Xunit;

namespace Unittests.MoveServiceTests
{
    [ExcludeFromCodeCoverage]
    public class GetIdMove :IDisposable
    {
        readonly MoveService moveService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public GetIdMove()
        {

            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);
        }

        [Fact]
        public void GetId_Should_ReturnMove()
        {
            //arrange

            //act
            Move move = moveService.Get(150);

            //assert
            Assert.True(move.Id == 150);
            Assert.True(move.Name == "Psychic");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void GetId_Should_ReturnNoMove(int id)
        {
            //arrange

            //act
            Move move = moveService.Get(id);

            //assert
            Assert.True(move.Id == 0);
            Assert.True(move.Name == "");
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
