using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Services
{
    public class GameFactory : IGameFactory
    {
        private readonly IGameLoop _gameLoop;
        private readonly IBoardService _boardService;
        private readonly IInteractionService _interactionService;

        public GameFactory(IGameLoop gameLoop, IBoardService boardService,
            IInteractionService interactionService)
        {
            _gameLoop = gameLoop;
            _boardService = boardService;
            _interactionService = interactionService;
        }

        public Game Create()
        {
            return new Game(_gameLoop, _boardService, _interactionService);
        }
    }
}
