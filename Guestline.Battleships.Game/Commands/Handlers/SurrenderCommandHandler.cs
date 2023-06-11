using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Commands.Handlers
{
    public class SurrenderCommandHandler : ISurrenderCommandHandler
    {
        private readonly ISemaphoreService _semaphoreService;

        public SurrenderCommandHandler(ISemaphoreService semaphoreService)
        {
            _semaphoreService = semaphoreService;
        }

        public void Handle(SurrenderCommand command)
        {
            _semaphoreService.Hit("surrender");
        }
    }
}
