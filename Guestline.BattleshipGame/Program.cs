using Guestline.BattleshipGame;
using Guestline.BattleshipGame.Domain.DomainServices;
using Guestline.BattleshipGame.Domain.Services;
using Guestline.BattleshipGame.Services;

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IBoardService, BoardService>();
services.AddTransient<IBoardPrinter, BoardPrinter>();
services.AddTransient<IRandomService, RandomService>();
services.AddTransient<IInteractionService, ConsoleService>();
services.AddSingleton<Game>();
services.AddSingleton<GameLoop>();

var serviceProvider = services.BuildServiceProvider();

var game = serviceProvider.GetService<Game>();
game.Play();

if (serviceProvider is IDisposable disposable)
{
    disposable.Dispose();
}