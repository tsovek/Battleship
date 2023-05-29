using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.ValueObjects;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Base;

namespace Guestline.Battleships.Game
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IInteractionService _interactionService;
        private readonly IBoardPrinter _boardPrinter;

        public GameLoop(IInteractionService interactionService, IBoardPrinter boardPrinter)
        {
            _interactionService = interactionService;
            _boardPrinter = boardPrinter;
        }

        public void Loop(Board board)
        {
            while (board.GameOver() == false)
            {
                string? rawInput = _interactionService.ReadInput();
                if (rawInput == "surrender")
                {
                    board.Surrender();
                    _interactionService.WriteOutput(_boardPrinter.Print(board));
                    break;
                }

                try
                {
                    var row = Row.From(rawInput);
                    var column = Column.From(rawInput);
                    AttemptResult attemptResult = board.TryHit(row, column);
                    
                    _interactionService.WriteOutput(attemptResult.Name);
                    _interactionService.WriteOutput(_boardPrinter.Print(board));
                }
                catch (BattleshipException e)
                {
                    _interactionService.WriteOutput(e.Message);
                }
                catch (Exception)
                {
                    _interactionService.WriteOutput("Unhandled error. Can't continue the game.");
                    break;
                }
            }
        }
    }
}
