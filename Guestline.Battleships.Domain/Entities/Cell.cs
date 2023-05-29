using Guestline.Battleships.Domain.Entities.Base;
using Guestline.Battleships.Domain.Exceptions;

namespace Guestline.Battleships.Domain.Entities
{
    internal class Cell : IReadOnlyCell
    {
        private bool _revealed = false;
        internal Warship? Warship { get; set; }

        internal AttemptResult Reveal()
        {
            if (_revealed) throw new RepeatedAttemptException();

            _revealed = true;
            var status = Warship?.Hit() ?? AttemptResult.Miss;

            return status;
        }

        internal void ForceReveal()
        {
            _revealed = true;
            Warship?.Hit();
        }

        public AttemptResult GetStatus()
        {
            if (_revealed == false) return AttemptResult.Unknown;

            return Warship?.GetStatus() ?? AttemptResult.Miss;
        }
    }
}