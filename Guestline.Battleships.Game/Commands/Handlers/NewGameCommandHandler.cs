using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Commands.Handlers
{
    public class NewGameCommandHandler : INewGameCommandHandler
    {
        private readonly IGameCache _gameCache;

        public NewGameCommandHandler(IGameCache gameCache)
        {
            _gameCache = gameCache;
        }

        public async Task HandleAsync(NewGameCommand command)
        {
            _gameCache.Create();

            Game game = _gameCache.Get();
            await game.Play();
        }
    }
}
