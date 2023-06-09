using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Base;

using System.Text;

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

        public void Play()
        {
            try
            {
                var board = new Board();
                _boardService.PlaceWarship(board, new Battleship());
                _boardService.PlaceWarship(board, new Destroyer());
                _boardService.PlaceWarship(board, new Destroyer());

                _gameLoop.Loop(board);
            }
            catch (Exception)
            {
                _interactionService.Output("Unhandled error. Can't continue the game.");
            }
        }
    }
}
