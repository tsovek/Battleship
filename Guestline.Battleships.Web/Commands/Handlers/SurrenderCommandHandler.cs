using Guestline.Battleships.Web.Commands.Handlers.Base;
using Guestline.Battleships.Web.Services.Base;

namespace Guestline.Battleships.Web.Commands.Handlers
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
