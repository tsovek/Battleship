namespace Guestline.BattleshipGame.Services
{
    public interface IInteractionService
    {
        void WriteLine(string? message);
        string? ReadLine();
    }
}
