using FluentAssertions;

using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.ValueObjects;

namespace Guestline.Battleships.Domain.Tests.Unit.Entities
{
    public class BoardTests
    {
        [Test]
        public void ShouldBeGameOver_WhenAllWarshipsAreSunk()
        {
            // ARRANGE
            var board = new Board();
            PlaceWarshipFromA1ToB1(board);
            PlaceWarshipFromI10ToJ10(board);

            // ACT & ASSERT
            AttemptResult attemptResult = board.TryHit(Row.From("A1"), Column.From("A1"));
            attemptResult.Should().Be(AttemptResult.Hit);
            board.GameOver().Should().BeFalse();

            attemptResult = board.TryHit(Row.From("B1"), Column.From("B1"));
            attemptResult.Should().Be(AttemptResult.HitAndSunk);
            board.GameOver().Should().BeFalse();

            attemptResult = board.TryHit(Row.From("I10"), Column.From("I10"));
            attemptResult.Should().Be(AttemptResult.Hit);
            board.GameOver().Should().BeFalse();

            attemptResult = board.TryHit(Row.From("J10"), Column.From("J10"));
            attemptResult.Should().Be(AttemptResult.HitAndSunk);
            board.GameOver().Should().BeTrue();
        }

        [Test]
        public void ShouldNotPerformAnyAction_WhenBoardSurrender()
        {
            // ARRANGE
            var board = new Board();
            PlaceWarshipFromA1ToB1(board);
            PlaceWarshipFromI10ToJ10(board);

            // ACT & ASSERT
            board.Surrender();

            this.Invoking(that => board.TryHit(Row.From("J10"), Column.From("J10")))
                .Should().Throw<RepeatedAttemptException>();
            board.GameOver().Should().BeTrue();
        }

        private void PlaceWarshipFromA1ToB1(Board board)
        {
            board.TryPlaceWarship(new WarshipMock(),
                Direction.Right, row: 0, column: 0);
        }

        private void PlaceWarshipFromI10ToJ10(Board board)
        {
            board.TryPlaceWarship(new WarshipMock(),
                Direction.Left, row: 9, column: 9);
        }

        private class WarshipMock : Warship
        {
            internal override int CellsToOccupy => 2;
        }
    }
}
