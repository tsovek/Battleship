using Guestline.BattleshipGame.Domain.DomainServices;
using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Exceptions;
using Guestline.BattleshipGame.Domain.ValueObjects;
using Guestline.BattleshipGame.Services;

namespace Guestline.BattleshipGame
{
    internal class GameLoop
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
            while (true)
            {
                string? rawInput = _interactionService.ReadLine();
                if (rawInput == "surrender")
                {
                    board.Surrender();
                    _interactionService.WriteLine(_boardPrinter.Print(board));
                    break;
                }

                try
                {
                    if (NextIteration(board, rawInput))
                    {
                        break;
                    }

                    _interactionService.WriteLine(_boardPrinter.Print(board));
                }
                catch (BattleshipException e)
                {
                    _interactionService.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    _interactionService.WriteLine("Unhandled error. Can't continue the game.");
                    break;
                }
            }
        }

        private bool NextIteration(Board board, string? rawInput)
        {
            var row = Row.From(rawInput);
            var column = Column.From(rawInput);
            ShotResult shotResult = board.TryShot(row, column);

            if (shotResult == ShotResult.Miss)
            {
                _interactionService.WriteLine("Miss!");
            }
            if (shotResult == ShotResult.Shot)
            {
                _interactionService.WriteLine("Shot!");
            }
            if (shotResult == ShotResult.ShotAndSunk)
            {
                _interactionService.WriteLine("Shot and sunk!");
            }
            if (shotResult == ShotResult.SunkAndWin)
            {
                _interactionService.WriteLine("You sunk the last ship! Congrats!");
                _interactionService.WriteLine(_boardPrinter.Print(board));
                return true;
            }
            return false;
        }
    }
}
