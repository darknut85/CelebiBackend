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
    public class CreateMove : IDisposable
    {
        readonly Move move;
        readonly Move existingMove;
        readonly Move emptyMove;
        readonly MoveService moveService;
        readonly DbContextOptions<DataContext> options;
        DataContext context;

        public CreateMove()
        {
            move = new Move()
            {
                Name = "Confusion",
                Type = "Psychic",
                Accuracy = 0,
                BasePower = 0,
                BattleEffect = "something",
                EffectRate = 0,
                Id = 0,
                PowerPoints = 0,
                Priority = 0,
                Target = ""
                  
            };
            existingMove = new Move() { Id = 150, Name = "Psychic" };
            emptyMove = new Move();
            options = this.CreatePostgreSqlUniqueClassOptions<DataContext>();
            context = new(options);
            context.DefaultSetup();
            moveService = new MoveService(context);

        }

        [Fact]
        public void Create_Should_MakeMove()
        {
            //arrange

            //act
            Move newMove = moveService.Create(move);

            //assert
            Assert.True(newMove.Id == move.Id);
            Assert.True(newMove.Name == move.Name);
        }

        [Fact]
        public void Create_ShouldNot_MakeMove_IfMoveExists()
        {
            //arrange

            //act
            Move newMove = moveService.Create(existingMove);

            //assert
            Assert.True(newMove.Id == 0);
        }

        [Fact]
        public void Create_Should_MakeMoveWithoutInfo()
        {
            //arrange

            //act
            Move newMove = moveService.Create(emptyMove);

            //assert
            Assert.Equal("", newMove.Name);
            Assert.Equal(0, newMove.PowerPoints);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }

}
