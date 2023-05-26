using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.BattleshipGame.Domain.Factories
{
    public interface IBoardFactory
    {
        Board Create();
    }
}