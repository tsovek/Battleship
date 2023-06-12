using Guestline.Battleships.Web.Commands.Handlers.Base;
using Guestline.Battleships.Web.Commands;

namespace Guestline.Battleships.Web.Endpoints
{
    internal class NewGame
    {
        public static IResult Do(IServiceProvider serviceProvider)
        {
            var handler = serviceProvider.GetService<INewGameCommandHandler>()
                ?? throw new InvalidOperationException($"Missing {nameof(INewGameCommandHandler)} dependency.");
            handler.HandleAsync(new NewGameCommand());

            return Results.Ok();
        }
    }
}
