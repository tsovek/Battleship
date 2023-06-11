using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Game.Services.Base
{
    public interface IInteractionService
    {
        Task Output(string message);
        Task Output(Board board);
        Task<string> ReadInput();
    }
}
