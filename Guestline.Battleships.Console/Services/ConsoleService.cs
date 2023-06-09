using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Base;

namespace Guestline.Battleships.Services
{
    public class ConsoleService : IInteractionService
    {
        private readonly IBoardPrinter _boardPrinter;

        public ConsoleService(IBoardPrinter boardPrinter)
        {
            _boardPrinter = boardPrinter;
        }

        public string? ReadInput() => Console.ReadLine();

        public void Output(string? message = null) => Console.WriteLine(message);

        public void Output(Board board)
        {
            string output = _boardPrinter.Print(board);

            Console.WriteLine(output);
        }
    }
}
