using Moq;
using Guestline.Battleships.Domain.Services;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Domain.Entities;
using System.Linq.Expressions;
using Guestline.Battleships.Domain.Exceptions;

namespace Guestline.Battleships.Domain.Tests.Unit.Services
{
    [TestFixture]
    public class BoardServiceTests
    {
        [Test]
        public void ShouldSuccessfullyPlaceWarship_WhenValidParametersChosen()
        {
            // ARRANGE
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock.SetupSequence(rs => rs.GetRandom(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(0).Returns(0).Returns(0) // 0, 0, left - impossible 
                .Returns(0).Returns(0).Returns(1);// 0, 0, right - possible!
            var board = new Board();
            var warship= new WarshipMock();

            var boardService = new BoardService(randomServiceMock.Object);

            // ACT & ASSERT
            try { boardService.PlaceWarship(board, warship); }
            catch { Assert.Fail("Should place!"); }
        }

        [Test]
        public void PlaceWarship_WhenPlacementFails_ThrowsPlacementIterationLimitExceededException()
        {
            // ARRANGE
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock.SetupSequence(rs => rs.GetRandom(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(0).Returns(0).Returns(0); // 0, 0, left - impossible 
            var board = new Board();
            var warship = new WarshipMock();

            var boardService = new BoardService(randomServiceMock.Object);

            // ACT & ASSERT
            Assert.Throws<PlacementIterationLimitExceededException>(() => boardService.PlaceWarship(board, warship));
        }

        private class WarshipMock : Warship
        {
            internal override int CellsToOccupy => 2;
        }
    }
}
