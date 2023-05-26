using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.BattleshipGame.Domain.DomainServices
{
    public interface IBoardPrinter
    {
        string Print(Board board);
        string? PrintLegend();
    }
}
