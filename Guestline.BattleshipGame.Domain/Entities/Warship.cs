namespace Guestline.BattleshipGame.Domain.Entities
{
    public abstract class Warship
    {
        private int _shots = 0;

        internal abstract int CellsToOccupy { get; }

        internal ShotResult Shot()
        {
            _shots++;

            return GetStatus();
        }

        internal ShotResult GetStatus()
        {
            if (_shots == 0) return ShotResult.Unknown;

            return IsSunk() ? ShotResult.ShotAndSunk : ShotResult.Shot;
        }

        internal bool IsSunk() => _shots >= CellsToOccupy;
    }
}
