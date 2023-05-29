using FluentAssertions;

using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Domain.Tests.Unit.Entities
{
    public class WarshipTests
    {
        [Test]
        public void ShouldStatusBeUnknown_WhenNotHitYet()
        { 
            // ARRANGE
            var warship = new TwoCellsWarship();

            // ACT
            AttemptResult attemptResult = warship.GetStatus();

            // ASSERT
            attemptResult.Should().Be(AttemptResult.Unknown);
            warship.IsSunk().Should().BeFalse();
        }

        [Test]
        public void ShouldStatusBeHit_WhenHitButNotSunkYet()
        {
            // ARRANGE
            var warship = new TwoCellsWarship();

            // ACT
            warship.Hit();

            // ASSERT
            warship.GetStatus().Should().Be(AttemptResult.Hit);
            warship.IsSunk().Should().BeFalse();
        }

        [Test]
        public void ShouldStatusBeHitAndSunk_WhenAllCellsHaveBeenHit()
        {
            // ARRANGE
            var warship = new TwoCellsWarship();

            // ACT
            warship.Hit();
            warship.Hit();

            // ASSERT
            warship.GetStatus().Should().Be(AttemptResult.HitAndSunk);
            warship.IsSunk().Should().BeTrue();
        }

        private class TwoCellsWarship : Warship
        {
            internal override int CellsToOccupy => 2;
        }
    }
}
