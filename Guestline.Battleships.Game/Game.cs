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
        private readonly IBoardPrinter _boardPrinter;

        public Game(IGameLoop gameLoop, IBoardService boardService, 
            IInteractionService interactionService, IBoardPrinter boardPrinter)
        {
            _gameLoop = gameLoop;
            _boardService = boardService;
            _interactionService = interactionService;
            _boardPrinter = boardPrinter;
        }

        public void Play()
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
                _interactionService.WriteOutput(e.Message);
            }
            catch (Exception)
            {
                _interactionService.WriteOutput("Unhandled error. Can't continue the game.");
            }
        }

        private void PrintInstructionAndLegend()
        {
            var sb = new StringBuilder();

            sb.AppendLine("This is Battleships game!");
            sb.AppendLine("The grid is hardcoded (10x10). Find one Battleship (5 cells) and two Destroyers (4 cells) to win.");
            sb.AppendLine("Letters A-J are columns (capital), numbers 1-10 are rows, i.e. B9.");
            sb.AppendLine("Type special command `surrender` to end the game and print warships' positions.");
            sb.AppendLine();
            sb.AppendLine("Legend on the board:");
            sb.AppendLine(_boardPrinter.PrintLegend());
            sb.AppendLine();

            _interactionService.WriteOutput(sb.ToString());
        }
    }
}
