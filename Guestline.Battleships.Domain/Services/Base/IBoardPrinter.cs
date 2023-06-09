using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Domain.Services.Base
{
    public interface IBoardPrinter
    {
        string Print(Board board);
    }
}
