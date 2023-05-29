using FluentAssertions;

using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.ValueObjects;

namespace Guestline.Battleships.Domain.Tests.Unit.Services.PlacementStrategies
{
    public class UpPlacementStrategyTests
    {
        private readonly static Direction UP = Direction.Up;

        [Test]
        public void ShouldPlaceWarship_WhenNoSideAlignmentConflict()
        {
            // ARRANGE
            var row = Row.From("A2");
            var column = Column.From("A2");
            var board = new Board();
            PlaceWarshipFromE5ToF5(board);

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), UP, row.IterableValue, column.IterableValue);

            // ASSERT
            success.Should().BeTrue();
        }

        [Test]
        public void ShouldNotPlaceWarship_WhenNoAvailablePlace()
        {
            // ARRANGE
            var row = Row.From("A1");
            var column = Column.From("A1");
            var board = new Board();

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), UP, row.IterableValue, column.IterableValue);

            // ASSERT
            success.Should().BeFalse();
        }

        [TestCase("E7")]
        [TestCase("E6")]
        [TestCase("E5")]
        [TestCase("E4")]
        [TestCase("F7")]
        [TestCase("F6")]
        [TestCase("F5")]
        [TestCase("F4")]
        [TestCase("D6")]
        [TestCase("D5")]
        [TestCase("G6")]
        [TestCase("G5")]
        public void ShouldNotPlaceWarship_WhenAnySizeAlignmentConflict(string startingPoint)
        {
            // ARRANGE
            var row = Row.From(startingPoint);
            var column = Column.From(startingPoint);
            var board = new Board();
            PlaceWarshipFromE5ToF5(board);

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), UP, row.IterableValue, column.IterableValue);

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
