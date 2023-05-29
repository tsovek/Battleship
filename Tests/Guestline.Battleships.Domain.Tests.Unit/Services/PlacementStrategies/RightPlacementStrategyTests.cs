using FluentAssertions;

using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.ValueObjects;

namespace Guestline.Battleships.Domain.Tests.Unit.Services.PlacementStrategies
{
    public class RightPlacementStrategyTests
    {
        private readonly static Direction RIGHT = Direction.Right;

        [Test]
        public void ShouldPlaceWarship_WhenNoSideAlignmentConflict()
        {
            // ARRANGE
            var row = Row.From("B4");
            var column = Column.From("B4");
            var board = new Board();
            PlaceWarshipFromE5ToF5(board);

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), RIGHT, row.IterableValue, column.IterableValue);

            // ASSERT
            success.Should().BeTrue();
        }

        [Test]
        public void ShouldNotPlaceWarship_WhenNoAvailablePlace()
        {
            // ARRANGE
            var row = Row.From("J1");
            var column = Column.From("J1");
            var board = new Board();

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), RIGHT, row.IterableValue, column.IterableValue);

            // ASSERT
            success.Should().BeFalse();
        }

        [TestCase("G5")]
        [TestCase("F5")]
        [TestCase("F6")]
        [TestCase("E4")]
        [TestCase("D5")]
        [TestCase("D4")]
        [TestCase("D6")]
        [TestCase("C5")]
        [TestCase("F4")]
        public void ShouldNotPlaceWarship_WhenAnySizeAlignmentConflict(string startingPoint)
        {
            // ARRANGE
            var row = Row.From(startingPoint);
            var column = Column.From(startingPoint);
            var board = new Board();
            PlaceWarshipFromE5ToF5(board);

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), RIGHT, row.IterableValue, column.IterableValue);

            // ASSERT
            success.Should().BeFalse();
        }

        private void PlaceWarshipFromE5ToF5(Board board)
        {
            board.TryPlaceWarship(new TwoCellsWarship(),
                Direction.Right, row: 4, column: 4);
        }

        private class TwoCellsWarship : Warship
        {
            internal override int CellsToOccupy => 2;
        }
    }
}
