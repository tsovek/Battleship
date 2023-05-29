using FluentAssertions;

using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;

namespace Guestline.Battleships.Domain.Tests.Unit.Entities
{
    public class CellTests
    {
        [Test]
        public void GetStatus_ShouldBeUnknown_WhenCellNotRevealedYet()
        {
            // ARRANGE
            var cell = new Cell();

            // ACT
            AttemptResult attemptResult = cell.GetStatus();

            // ASSERT
            attemptResult.Should().Be(AttemptResult.Unknown);
        }

        [Test]
        public void ShouldBeMiss_WhenCellRevealedButNoWarship()
        {
            // ARRANGE
            var cell = new Cell();

            // ACT
            cell.Reveal();
            AttemptResult attemptResult = cell.GetStatus();

            // ASSERT
            attemptResult.Should().Be(AttemptResult.Miss);
        }

        [Test]
        public void ShouldBeTakenFromWarship_WhenCellRevealedAndHaveWarship()
        {
            // ARRANGE
            var warship = new TwoCellsWarship();
            warship.Hit();
            var cell = new Cell();
            cell.Warship = warship;

            // ACT
            cell.Reveal();
            AttemptResult attemptResult = cell.GetStatus();

            // ASSERT
            attemptResult.Should().Be(warship.GetStatus());
        }

        [Test]
        public void ShouldThrowException_WhenCellAlreadyRevealed()
        {
            // ARRANGE
            var cell = new Cell();

            // ACT & ASSERT
            cell.Reveal();
            this.Invoking(that => cell.Reveal())
                .Should().Throw<RepeatedAttemptException>();
        }

        [Test]
        public void ShouldAllowMultipleReveals_WhenForceRevealInvoked()
        {
            // ARRANGE
            var cell = new Cell();

            // ACT & ASSERT
            cell.Reveal();
            this.Invoking(that => cell.ForceReveal())
                .Should().NotThrow<RepeatedAttemptException>();
        }

        private class TwoCellsWarship : Warship
        {
            internal override int CellsToOccupy => 2;
        }
    }
}
