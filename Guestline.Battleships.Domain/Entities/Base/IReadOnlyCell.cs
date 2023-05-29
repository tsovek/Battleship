namespace Guestline.Battleships.Domain.Entities.Base
{
    public interface IReadOnlyCell
    {
        AttemptResult GetStatus();
    }
}
