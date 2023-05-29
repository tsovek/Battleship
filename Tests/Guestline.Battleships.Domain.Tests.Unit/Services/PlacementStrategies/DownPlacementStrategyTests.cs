using FluentAssertions;

using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.ValueObjects;

namespace Guestline.Battleships.Domain.Tests.Unit.Services.PlacementStrategies
{
    public class DownPlacementStrategyTests
    {
        private readonly static Direction DOWN = Direction.Down;

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
                new TwoCellsWarship(), DOWN, row.IterableValue, column.IterableValue);

            // ASSERT
            success.Should().BeTrue();
        }

        [Test]
        public void ShouldNotPlaceWarship_WhenNoAvailablePlace()
        {
            // ARRANGE
            var row = Row.From("A10");
            var column = Column.From("A10");
            var board = new Board();

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), DOWN, row.IterableValue, column.IterableValue);

            // ASSERT
            success.Should().BeFalse();
        }

        [TestCase("E4")]
        [TestCase("E4")]
        [TestCase("F3")]
        [TestCase("F4")]
        [TestCase("E5")]
        [TestCase("F5")]
        [TestCase("D5")]
        [TestCase("G5")]
        [TestCase("E6")]
        [TestCase("F6")]
        public void ShouldNotPlaceWarship_WhenAnySizeAlignmentConflict(string startingPoint)
        {
            // ARRANGE
            var row = Row.From(startingPoint);
            var column = Column.From(startingPoint);
            var board = new Board();
            PlaceWarshipFromE5ToF5(board);

            // ACT
            bool success = board.TryPlaceWarship(
                new TwoCellsWarship(), DOWN, row.IterableValue, column.IterableValue);

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
