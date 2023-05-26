namespace Guestline.BattleshipGame.Services
{

    public class ConsoleService : IInteractionService
    {
        public string? ReadLine() => Console.ReadLine();

        public void WriteLine(string? message = null) => Console.WriteLine(message);
    }
}
