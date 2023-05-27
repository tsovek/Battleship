using Guestline.BattleshipGame.Domain.Entities.Abstract;
using Guestline.BattleshipGame.Domain.Exceptions;

namespace Guestline.BattleshipGame.Domain.Entities
{
    internal class Cell : IReadOnlyCell
    {
        private bool _revealed = false;
        internal Warship? Warship { get; set; }

        internal ShotResult Reveal()
        {
            if (_revealed) throw new RepeatedAttemptException();

            _revealed = true;
            var status = Warship?.Shot() ?? ShotResult.Miss;

            return status;
        }

        internal void ForceReveal()
        {
            _revealed = true;
            Warship?.Shot();
        }

        public ShotResult GetStatus()
        {
            if (_revealed == false) return ShotResult.Unknown;

            return Warship?.GetStatus() ?? ShotResult.Miss;
        }
    }
}