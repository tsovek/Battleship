namespace Guestline.Battleships.Domain.Entities
{
    public abstract class Warship
    {
        private int _shots = 0;

        internal abstract int CellsToOccupy { get; }

        internal AttemptResult Hit()
        {
            _shots++;

            return GetStatus();
        }

        internal AttemptResult GetStatus()
        {
            if (_shots == 0) return AttemptResult.Unknown;

            return IsSunk() ? AttemptResult.HitAndSunk : AttemptResult.Hit;
        }

        internal bool IsSunk() => _shots >= CellsToOccupy;
    }
}
