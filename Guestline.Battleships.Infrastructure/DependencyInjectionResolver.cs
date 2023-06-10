using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Domain.Services;
using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Commands.Handlers;
using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Game.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Guestline.Battleships.Infrastructure
{
    public class DependencyInjectionResolver : IDisposable
    {
        private readonly IServiceCollection _serviceCollection;

        public DependencyInjectionResolver(IServiceCollection services)
        {
            _serviceCollection = services;
        }

        public IServiceProvider RegisterCommon()
        {
            _serviceCollection.AddTransient<IBoardService, BoardService>();
            _serviceCollection.AddTransient<IBoardPrinter, BoardPrinter>();
            _serviceCollection.AddTransient<IGameLoop, GameLoop>();
            _serviceCollection.AddTransient<IGameFactory, GameFactory>();
            _serviceCollection.AddTransient<IHitCommandHandler, HitCommandHandler>();
            _serviceCollection.AddTransient<INewGameCommandHandler, NewGameCommandHandler>();
            _serviceCollection.AddTransient<IRandomService, RandomService>();
            _serviceCollection.AddSingleton<IGameCache, GameCache>();
            
            return _serviceCollection.BuildServiceProvider();
        }

        public void RegisterSingleton<TAbstraction, TImplementation>()
            where TAbstraction : class
            where TImplementation : class, TAbstraction
        {
            _serviceCollection.AddSingleton<TAbstraction, TImplementation>();
        }

        public void Dispose()
        {
            if (_serviceCollection is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
