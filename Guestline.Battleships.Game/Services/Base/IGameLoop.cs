using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Game.Services.Base
{
    public interface IGameLoop
    {
        Task Loop(Board board);
    }
}
