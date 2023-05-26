namespace Guestline.BattleshipGame.Domain.Services
{

    public class RandomService : IRandomService
    {
        private readonly Random _random = new Random();

        public int GetRandom(int from, int to)
        {
            return _random.Next(from, to);
        }
    }
}
