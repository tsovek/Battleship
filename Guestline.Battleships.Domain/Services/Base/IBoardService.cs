using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Domain.Services.Base
{
    public interface IBoardService
    {
        void PlaceWarship(Board board, Warship warship);
    }
}
