namespace Guestline.Battleships.Game.Commands.Handlers.Base
{
    public interface INewGameCommandHandler
    {
        Task ExecuteAsync(NewGameCommand command);
    }
}
