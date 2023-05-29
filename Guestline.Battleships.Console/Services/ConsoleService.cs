using Guestline.Battleships.Game.Base;

namespace Guestline.Battleships.Services
{
    public class ConsoleService : IInteractionService
    {
        public string? ReadInput() => Console.ReadLine();

        public void WriteOutput(string? message = null) => Console.WriteLine(message);
    }
}
