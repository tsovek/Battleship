using Guestline.BattleshipGame.Domain.Services;
using Guestline.BattleshipGame.Services;
using Guestline.Battleships.Domain.Services;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game;
using Guestline.Battleships.Game.Base;

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IBoardService, BoardService>();
services.AddTransient<IBoardPrinter, BoardPrinter>();
services.AddTransient<IRandomService, RandomService>();
services.AddTransient<IInteractionService, ConsoleService>();
services.AddSingleton<IGameLoop, GameLoop>();
services.AddSingleton<Game>();

var serviceProvider = services.BuildServiceProvider();

var game = serviceProvider.GetService<Game>();
game.Play();

Console.ReadKey();

if (serviceProvider is IDisposable disposable)
{
    disposable.Dispose();
}