using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Base;

using Moq;

namespace Guestline.Battleships.Game.Tests.Unit
{
    public class GameTests
    {
        private Mock<IBoardService> _boardServiceMock;
        private Mock<IGameLoop> _gameLoopMock;
        private Mock<IInteractionService> _interactionServiceMock;
        private Mock<IBoardPrinter> _boardPrinterMock;
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _boardServiceMock = new Mock<IBoardService>();
            _gameLoopMock = new Mock<IGameLoop>();
            _interactionServiceMock = new Mock<IInteractionService>();
            _boardPrinterMock = new Mock<IBoardPrinter>();

            _game = new Game(
                _gameLoopMock.Object,
                _boardServiceMock.Object,
                _interactionServiceMock.Object
            );
        }

        [Test]
        public void ShouldInitBoardAndPlaceWarships_WhenNoException()
        {
            // ARRANGE & ACT
            _game.Play();

            // ASSERT
            AssertPlacementHasBeenMadeAtLeastOnce();
            AssertLoopHasBeenCalled();
        }

        [Test]
        public void ShouldCatchAndWriteGeneralError_WhenAnyExceptionIsThrown()
        {
            // ARRANGE
            _gameLoopMock
                .Setup(loop => loop.Loop(It.IsAny<Board>()))
                .Throws(new ArgumentException("This is error!"));

            // ACT
            _game.Play();

            // ASSERT
            AssertPlacementHasBeenMadeAtLeastOnce();
            AssertErrorHasBeenLogged("Unhandled error. Can't continue the game.");
        }

        private void AssertLoopHasBeenCalled()
            => _gameLoopMock.Verify(loop => loop.Loop(It.IsAny<Board>()), Times.Once());

        private void AssertErrorHasBeenLogged(string errorMessage)
            => _interactionServiceMock.Verify(i => i.Output(errorMessage), Times.Once());

        private void AssertPlacementHasBeenMadeAtLeastOnce()
            => _boardServiceMock.Verify(b => b.PlaceWarship(It.IsAny<Board>(), It.IsAny<Warship>()), Times.AtLeastOnce());
    }
}
