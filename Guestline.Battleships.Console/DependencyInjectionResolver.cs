using Guestline.Battleships.Console.Services;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Domain.Services;
using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Game.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Guestline.Battleships.Console
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
            _serviceCollection.AddTransient<IRandomService, RandomService>();
            _serviceCollection.AddTransient<IInteractionService, ConsoleService>();

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
