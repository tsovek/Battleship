using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Commands;

namespace Guestline.Battleships.Web.Endpoints
{
    internal class NewGame
    {
        public static IResult Do(IServiceProvider serviceProvider)
        {
            var handler = serviceProvider.GetService<INewGameCommandHandler>();
            handler.HandleAsync(new NewGameCommand());

            return Results.Ok();
        }
    }
}
