namespace Guestline.Battleships.Domain.Services.Base
{
    public interface IRandomService
    {
        int GetRandom(int from, int to);
    }
}
