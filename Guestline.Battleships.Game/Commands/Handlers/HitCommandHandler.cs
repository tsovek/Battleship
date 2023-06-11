using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Commands.Handlers
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
            _semaphoreService.Hit(command.Coordinates);
        }
    }
}
