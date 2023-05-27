namespace Guestline.BattleshipGame.Domain.Entities.Abstract
{
    public interface IReadOnlyCell
    {
        ShotResult GetStatus();
    }
}
