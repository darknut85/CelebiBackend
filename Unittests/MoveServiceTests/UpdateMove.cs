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
    public class UpdateMove : IDisposable
    {
        readonly Move move;
        readonly Move emptyMove;
        readonly MoveService moveService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public UpdateMove()
        {
            move = new Move()
            {
                Id = 1,
                Accuracy = 1,
                BasePower = 1,
                BattleEffect = "Flow",
                EffectRate = 1,
                Name = "Namid",
                PowerPoints = 1,
                Priority = 1,
                Target = "Me",
                Type = "Dark"
            };

            emptyMove = new Move();
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);
        }

        [Fact]
        public void Update_Should_ChangeMove()
        {
            //arrange

            //act
            Move updatedMove = moveService.Update(move);

            //assert
            Assert.True(updatedMove.Id == move.Id);
            Assert.True(updatedMove.Name == move.Name);
        }

        [Fact]
        public void Update_Should_ReturnNewMove_WhenUpdatingMoveWithoutInfo()
        {
            //arrange

            //act
            Move updatedMove = moveService.Update(emptyMove);

            //assert
            Assert.True(updatedMove.Id == 0);
            Assert.True(updatedMove.Name == "");
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
