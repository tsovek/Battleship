using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.Battleships.Game.Base
{
    public interface IGameLoop
    {
        void Loop(Board board);
    }
}
