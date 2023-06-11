using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Commands;

namespace Guestline.Battleships.Web.Endpoints
{
    internal class Surrender
    {
        public static IResult Do(IServiceProvider serviceProvider)
        {
            var handler = serviceProvider.GetService<ISurrenderCommandHandler>();
            handler.Handle(new SurrenderCommand());

            return Results.Ok();
        }
    }
}
