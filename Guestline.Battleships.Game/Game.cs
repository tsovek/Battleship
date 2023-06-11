using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game
{
    public sealed class Game
    {
        private readonly IGameLoop _gameLoop;
        private readonly IBoardService _boardService;
        private readonly IInteractionService _interactionService;

        public Game(IGameLoop gameLoop, IBoardService boardService,
            IInteractionService interactionService)
        {
            _gameLoop = gameLoop;
            _boardService = boardService;
            _interactionService = interactionService;
        }

        public async Task Play()
        {
            try
            {
                var board = new Board();
                _boardService.PlaceWarship(board, new Battleship());
                _boardService.PlaceWarship(board, new Destroyer());
                _boardService.PlaceWarship(board, new Destroyer());

                await _gameLoop.Loop(board);
            }
            catch (Exception)
            {
                await _interactionService.Output("Unhandled error. Can't continue the game.");
            }
        }
    }
}
