using Guestline.Battleships.Web.Commands.Handlers.Base;
using Guestline.Battleships.Web.Commands;

namespace Guestline.Battleships.Web.Endpoints
{
    internal class Surrender
    {
        public static IResult Do(IServiceProvider serviceProvider)
        {
            var handler = serviceProvider.GetService<ISurrenderCommandHandler>()
                ?? throw new InvalidOperationException($"Missing {nameof(ISurrenderCommandHandler)} dependency.");
            handler.Handle(new SurrenderCommand());

            return Results.Ok();
        }
    }
}
