using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Commands;

namespace Guestline.Battleships.Web.Endpoints
{
    internal class Hit
    {
        public static IResult Do(IServiceProvider serviceProvider, string coordinates)
        {
            var handler = serviceProvider.GetService<IHitCommandHandler>();
            handler.Handle(new HitCommand { Coordinates = coordinates });

            return Results.Ok();
        }
    }
}
