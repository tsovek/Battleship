using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Services
{
    public class ConsoleService : IInteractionService
    {
        private readonly IBoardPrinter _boardPrinter;

        public ConsoleService(IBoardPrinter boardPrinter)
        {
            _boardPrinter = boardPrinter;
        }

        public async Task<string> ReadInput()
        {
            return await Task.FromResult(System.Console.ReadLine() ?? "");
        }

        public async Task Output(string message)
        {
            System.Console.WriteLine(message);

            await Task.CompletedTask;
        }

        public async Task Output(Board board)
        {
            string output = _boardPrinter.Print(board);

            System.Console.WriteLine(output);

            await Task.CompletedTask;
        }
    }
}
