using Guestline.BattleshipGame.Domain.DomainServices;
using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Exceptions;
using Guestline.BattleshipGame.Services;

namespace Guestline.BattleshipGame
{
    internal class GameLoop
    {
        private readonly IInteractionService _interactionService;
        private readonly IBoardPrinter _boardPrinter;
        private readonly IInputParser _inputParser;

        public GameLoop(IInteractionService interactionService, IBoardPrinter boardPrinter,
            IInputParser inputParser)
        {
            _interactionService = interactionService;
            _boardPrinter = boardPrinter;
            _inputParser = inputParser;
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
            (char column, int row) = _inputParser.Parse(rawInput);
            ShotResult shotResult = board.TryShot(row.ToRowIndex(), column.ToColumnIndex());
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
