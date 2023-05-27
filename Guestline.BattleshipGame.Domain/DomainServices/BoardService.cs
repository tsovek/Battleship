using Guestline.BattleshipGame.Domain.DomainServices.Strategies;
using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Exceptions;
using Guestline.BattleshipGame.Domain.Services;

namespace Guestline.BattleshipGame.Domain.DomainServices
{
    public class BoardService : IBoardService
    {
        private readonly IRandomService _randomService;

        public BoardService(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public void PlaceWarship(Board board, Warship warship)
        {
            const int size = Constants.BOARD_SIZE;
            const int max_iterations = Constants.MAX_PLACEMENT_ITERATIONS;
            int iteration = 0;
            while (iteration < max_iterations)
            {
                iteration++;

                int rowStart = _randomService.GetRandom(0, size - 1);
                int columnStart = _randomService.GetRandom(0, size - 1);
                var direction = (Direction)_randomService.GetRandom(0, 3);
                var placementStrategy = PlacementStrategy.Create(direction);
                if (board.TryPlaceWarship(placementStrategy, warship, rowStart, columnStart))
                {
                    return;
                }
            }

            throw new PlacementIterationLimitExceededException();
        }
    }
}
