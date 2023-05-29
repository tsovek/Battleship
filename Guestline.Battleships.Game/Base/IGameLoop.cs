using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Game.Base
{
    public interface IGameLoop
    {
        void Loop(Board board);
    }
}
