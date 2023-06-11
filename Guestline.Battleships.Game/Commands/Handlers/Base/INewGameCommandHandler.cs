namespace Guestline.Battleships.Game.Commands.Handlers.Base
{
    public interface INewGameCommandHandler
    {
        Task HandleAsync(NewGameCommand command);
    }
}
