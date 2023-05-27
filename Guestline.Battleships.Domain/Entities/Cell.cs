using Guestline.BattleshipGame.Domain.Entities.Base;
using Guestline.BattleshipGame.Domain.Exceptions;

namespace Guestline.BattleshipGame.Domain.Entities
{
    internal class Cell : IReadOnlyCell
    {
        private bool _revealed = false;
        internal Warship? Warship { get; set; }

        internal AttemptResult Reveal()
        {
            if (_revealed) throw new RepeatedAttemptException();

            _revealed = true;
            var status = Warship?.Shot() ?? AttemptResult.Miss;

            return status;
        }

        internal void ForceReveal()
        {
            _revealed = true;
            Warship?.Shot();
        }

        public AttemptResult GetStatus()
        {
            if (_revealed == false) return AttemptResult.Unknown;

            return Warship?.GetStatus() ?? AttemptResult.Miss;
        }
    }
}