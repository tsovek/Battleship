using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.BattleshipGame.Domain.DomainServices
{
    public interface IBoardService
    {
        void PlaceWarship(Board board, Warship warship);
    }
}
