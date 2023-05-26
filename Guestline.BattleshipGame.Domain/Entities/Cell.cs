using Guestline.BattleshipGame.Domain.Exceptions;

namespace Guestline.BattleshipGame.Domain.Entities
{
    internal class Cell
    {
        private bool _revealed = false;
        internal Warship? Warship { get; set; }

        public ShotResult Reveal(bool forceReveal = false)
        {
            if (forceReveal == false && _revealed) throw new RepeatedAttemptException();

            _revealed = true;
            var status = Warship?.Shot() ?? ShotResult.Miss;

            return status;
        }

        public ShotResult GetStatus()
        {
            if (_revealed == false) return ShotResult.Unknown;

            return Warship?.GetStatus() ?? ShotResult.Miss;
        }
    }
}