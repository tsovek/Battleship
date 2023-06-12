using Guestline.Battleships.Console;
using Guestline.Battleships.Game;
using Guestline.Battleships.Game.Services.Base;

using Microsoft.Extensions.DependencyInjection;

Instruction.Print();

using var dependencyInjectionResolver = new DependencyInjectionResolver(new ServiceCollection());
IServiceProvider serviceProvider = dependencyInjectionResolver.RegisterCommon();

var gameFactory = serviceProvider.GetService<IGameFactory>() ?? throw new InvalidOperationException("Game can't be initialized.");
Game game = gameFactory.Create();
game.PlayAsync().GetAwaiter().GetResult();

Console.ReadKey();
