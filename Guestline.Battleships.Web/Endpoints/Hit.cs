using Guestline.Battleships.Web.Commands.Handlers.Base;
using Guestline.Battleships.Web.Commands;

namespace Guestline.Battleships.Web.Endpoints
{
    internal class Hit
    {
        public static IResult Do(IServiceProvider serviceProvider, string coordinates)
        {
            var handler = serviceProvider.GetService<IHitCommandHandler>() 
                ?? throw new InvalidOperationException($"Missing {nameof(IHitCommandHandler)} dependency.");
            handler.Handle(new HitCommand { Coordinates = coordinates });

            return Results.Ok();
        }
    }
}
