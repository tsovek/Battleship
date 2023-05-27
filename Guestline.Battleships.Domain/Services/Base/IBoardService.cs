using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.Battleships.Domain.Services.Base
{
    public interface IBoardService
    {
        void PlaceWarship(Board board, Warship warship);
    }
}
