namespace Guestline.Battleships.Web.Commands.Handlers.Base
{
    public interface INewGameCommandHandler
    {
        Task HandleAsync(NewGameCommand command);
    }
}
