namespace Guestline.Battleships.Game.Base
{
    public interface IInteractionService
    {
        void WriteOutput(string? message);
        string? ReadInput();
    }
}
