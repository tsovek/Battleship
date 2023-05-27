using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.Battleships.Domain.Services.Base
{
    public interface IBoardPrinter
    {
        string Print(Board board);
        string? PrintLegend();
    }
}
