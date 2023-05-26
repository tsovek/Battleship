using Guestline.BattleshipGame.Domain.DomainServices;
using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Exceptions;
using Guestline.BattleshipGame.Services;

namespace Guestline.BattleshipGame
{
    internal class Game
    {
        private readonly GameLoop _gameLoop;
        private readonly IBoardService _boardService;
        private readonly IInteractionService _interactionService;
        private readonly IBoardPrinter _boardPrinter;

        public Game(GameLoop gameLoop, IBoardService boardService, 
            IInteractionService interactionService, IBoardPrinter boardPrinter)
        {
            _gameLoop = gameLoop;
            _boardService = boardService;
            _interactionService = interactionService;
            _boardPrinter = boardPrinter;
        }

        internal virtual void Play()
        {
            try
            {
                PrintInstructionAndLegend();

                var board = new Board();
                _boardService.PlaceWarship(board, new Battleship());
                _boardService.PlaceWarship(board, new Destroyer());
                _boardService.PlaceWarship(board, new Destroyer());

                _gameLoop.Loop(board);
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
    }
}
