using Guestline.Battleships.Domain.Services.Base;

namespace Guestline.Battleships.Game.Services
{
    public class RandomService : IRandomService
    {
        private readonly Random _random = new();

        public int GetRandom(int from, int to)
        {
            return _random.Next(from, to);
        }
    }
}
