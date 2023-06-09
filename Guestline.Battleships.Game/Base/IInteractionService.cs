using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Game.Base
{
    public interface IInteractionService
    {
        void Output(string? message);
        void Output(Board board);
        string? ReadInput();
    }
}
