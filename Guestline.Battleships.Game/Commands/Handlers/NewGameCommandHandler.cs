using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Commands.Handlers
{
    public class NewGameCommandHandler : INewGameCommandHandler
    {
        private readonly IGameCache _gameCache;
        private readonly ISemaphoreService _semaphoreService;

        public NewGameCommandHandler(IGameCache gameCache,
            ISemaphoreService semaphoreService)
        {
            _gameCache = gameCache;
            _semaphoreService = semaphoreService;
        }

        public async Task HandleAsync(NewGameCommand command)
        {
            Game game = _gameCache.Get();
            if (game != null)
            {
                _semaphoreService.Cancel();
            }

            _gameCache.Create();
            game = _gameCache.Get();
            
            await game.Play();
        }
    }
}
