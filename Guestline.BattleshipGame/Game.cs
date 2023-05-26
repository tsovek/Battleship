using Guestline.BattleshipGame.Domain.DomainServices;
using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Exceptions;
using Guestline.BattleshipGame.Services;

namespace Guestline.BattleshipGame
{
    internal class Game
    {
        private readonly IBoardService _boardService;
        private readonly IInteractionService _interactionService;
        private readonly IInputParser _inputParser;
        private readonly IBoardPrinter _boardPrinter;

        public Game(IBoardService boardService, IInteractionService interactionService, 
            IInputParser inputParser, IBoardPrinter boardPrinter)
        {
            _boardService = boardService;
            _interactionService = interactionService;
            _inputParser = inputParser;
            _boardPrinter = boardPrinter;
        }

        internal void Play()
        {
            try
            {
                PrintInstructionAndLegend();

                var board = new Board();
                _boardService.PlaceWarship(board, new Battleship());
                _boardService.PlaceWarship(board, new Destroyer());
                _boardService.PlaceWarship(board, new Destroyer());

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
            catch (BattleshipException e)
            {
                _interactionService.WriteLine(e.Message);
            }
            catch (Exception)
            {
                _interactionService.WriteLine("Unhandled error. Can't continue the game.");
            }

            _interactionService.ReadLine();
        }

        private void PrintInstructionAndLegend()
        {
            _interactionService.WriteLine("This is Battleship game!");
            _interactionService.WriteLine("The grid is hardcoded (10x10). Find one Battleship (5 cells) and two Destroyers (4 cells) to win.");
            _interactionService.WriteLine("Letters A-J are columns (capital), numbers 1-10 are rows, i.e. B9.");
            _interactionService.WriteLine("Type special command `surrender` to end the game and print warships' positions.");
            _interactionService.WriteLine("");
            _interactionService.WriteLine("Legend on the board:");
            _interactionService.WriteLine(_boardPrinter.PrintLegend());
            _interactionService.WriteLine("");
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
