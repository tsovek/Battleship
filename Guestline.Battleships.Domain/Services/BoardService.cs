using Guestline.Battleships.Domain;
using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Domain.Services.PlacementStrategies;

namespace Guestline.Battleships.Domain.Services
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
            while (++iteration < max_iterations)
            {
                int row = _randomService.GetRandom(0, size - 1);
                int column = _randomService.GetRandom(0, size - 1);
                var direction = (Direction)_randomService.GetRandom(0, 3);
                
                bool success = board.TryPlaceWarship(warship, direction, row, column);
                if (success) return;
            }

            throw new BoardTooComplexException();
        }
    }
}
