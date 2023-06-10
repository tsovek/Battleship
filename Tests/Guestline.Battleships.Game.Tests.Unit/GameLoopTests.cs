using Moq;
using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using FluentAssertions;
using Guestline.Battleships.Game.Services;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Tests.Unit
{
    [TestFixture]
    public class GameLoopTests
    {
        private Mock<IInteractionService> _interactionServiceMock;
        private GameLoop _gameLoop;

        [SetUp]
        public void Setup()
        {
            _interactionServiceMock = new Mock<IInteractionService>();
            _gameLoop = new GameLoop(
                _interactionServiceMock.Object
            );
        }

        [Test]
        public void ShouldEndTheGame_WhenAllWarshipsAreSunk()
        {
            // ARRANGE
            Board board = CreateBoardWithWarshipFromA1ToC1();
            _interactionServiceMock.SetupSequence(i => i.ReadInput())
                .Returns(Task.FromResult("A1"))
                .Returns(Task.FromResult("B1"))
                .Returns(Task.FromResult("G5"))
                .Returns(Task.FromResult("C1"))
                .Throws(new InvalidOperationException("Too many attempts!"));

            // ACT
            _gameLoop.Loop(board);

            // ASSERT
            AssertMessageOutput(AttemptResult.Miss.Name, Times.Once());
            AssertMessageOutput(AttemptResult.Hit.Name, Times.Exactly(2));
            AssertMessageOutput(AttemptResult.HitAndSunk.Name, Times.Once());
            AssertBoardHasBeenPrinted(Times.Exactly(4));
        }

        [Test]
        public void ShouldSurrenderAndBreakLoop_WhenUserGivesUp()
        {
            // ARRANGE
            Board board = CreateBoardWithWarshipFromA1ToC1();
            _interactionServiceMock.SetupSequence(i => i.ReadInput())
                .Returns(Task.FromResult("G5"))
                .Returns(Task.FromResult("surrender"));

            // ACT
            _gameLoop.Loop(board);

            // ASSERT
            AssertMessageOutput(AttemptResult.Miss.Name, Times.Once());
            AssertBoardHasBeenPrinted(Times.Exactly(2));
        }

        [Test]
        public void ShouldWriteOutputAndContinueLoop_WhenInvalidInput()
        {
            // ARRANGE
            Board board = CreateBoardWithWarshipFromA1ToC1();
            _interactionServiceMock.SetupSequence(service => service.ReadInput())
                .Returns(Task.FromResult("A1"))
                .Returns(Task.FromResult("invalidInput"))
                .Returns(Task.FromResult("B1"))
                .Returns(Task.FromResult("C1"))
                .Throws(new InvalidOperationException("Too many attempts!"));

            // ACT
            _gameLoop.Loop(board);

            // ASSERT
            AssertMessageOutput(new InvalidInputException("invalidInput").Message, Times.Once());
            AssertBoardHasBeenPrinted(Times.Exactly(3));
        }

        [Test]
        public void ShouldCatchAndWriteGeneralError_WhenAnyExceptionIsThrown()
        {
            // ARRANGE
            Board board = CreateBoardWithWarshipFromA1ToC1();
            _interactionServiceMock.Setup(service => service.ReadInput()).Returns(Task.FromResult("A1"));
            _interactionServiceMock.Setup(b => b.Output(It.IsAny<Board>())).Throws<ArgumentException>();

            // ACT & ASSERT
            this.Invoking(that => _gameLoop.Loop(board).GetAwaiter().GetResult())
                .Should()
                .Throw<ArgumentException>();
        }

        private void AssertBoardHasBeenPrinted(Times times)
            => _interactionServiceMock.Verify(b => b.Output(It.IsAny<Board>()), times);

        private void AssertMessageOutput(string message, Times times)
            => _interactionServiceMock.Verify(i => i.Output(message), times);


        private Board CreateBoardWithWarshipFromA1ToC1()
        {
            var board = new Board();
            board.TryPlaceWarship(new WarshipMock(),
                Direction.Right, row: 0, column: 0);

            return board;
        }

        private class WarshipMock : Warship
        {
            internal override int CellsToOccupy => 3;
        }
    }
}
