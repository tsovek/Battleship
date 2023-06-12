using Guestline.Battleships.Web.Commands.Handlers.Base;
using Guestline.Battleships.Web.Services.Base;

namespace Guestline.Battleships.Web.Commands.Handlers
{
    public class HitCommandHandler : IHitCommandHandler
    {
        private readonly ISemaphoreService _semaphoreService;
        private readonly IGameCache _gameCache;

        public HitCommandHandler(
            ISemaphoreService semaphoreService,
            IGameCache gameCache)
        {
            _semaphoreService = semaphoreService;
            _gameCache = gameCache;
        }

        public void Handle(HitCommand command)
        {
            _semaphoreService.Hit(command.Coordinates ?? throw new InvalidOperationException("Invalid input"));
        }
    }
}
