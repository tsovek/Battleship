namespace Guestline.BattleshipGame.Domain.Entities.Base
{
    public interface IReadOnlyCell
    {
        AttemptResult GetStatus();
    }
}
