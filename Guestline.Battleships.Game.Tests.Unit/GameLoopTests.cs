using Moq;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Base;
using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.ValueObjects;
using Guestline.Battleships.Domain.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Guestline.Battleships.Game.Tests.Unit
{
    [TestFixture]
    public class GameLoopTests
    {
        private Mock<IInteractionService> _interactionServiceMock;
        private Mock<IBoardPrinter> _boardPrinterMock;
        private GameLoop _gameLoop;

        [SetUp]
        public void Setup()
        {
            _interactionServiceMock = new Mock<IInteractionService>();
            _boardPrinterMock = new Mock<IBoardPrinter>();
            _gameLoop = new GameLoop(
                _interactionServiceMock.Object,
                _boardPrinterMock.Object
            );
        }

        [Test]
        public void ShouldEndTheGame_WhenAllWarshipsAreSunk()
        {
            // ARRANGE
            Board board = CreateBoardWithWarshipFromA1ToC1();
            _interactionServiceMock.SetupSequence(i => i.ReadInput())
                .Returns("A1")
                .Returns("B1")
                .Returns("G5")
                .Returns("C1")
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
                .Returns("G5")
                .Returns("surrender");

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
                .Returns("A1")
                .Returns("invalidInput")
                .Returns("B1")
                .Returns("C1")
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
            _interactionServiceMock.Setup(service => service.ReadInput()).Returns("A1");
            _boardPrinterMock.Setup(b => b.Print(It.IsAny<Board>())).Throws<ArgumentException>();

            // ACT
            _gameLoop.Loop(board);

            // ASSERT
            AssertMessageOutput("Unhandled error. Can't continue the game.", Times.Once());
        }

        private void AssertBoardHasBeenPrinted(Times times)
            => _boardPrinterMock.Verify(b => b.Print(It.IsAny<Board>()), times);

        private void AssertMessageOutput(string message, Times times)
            => _interactionServiceMock.Verify(i => i.WriteOutput(message), times);


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
