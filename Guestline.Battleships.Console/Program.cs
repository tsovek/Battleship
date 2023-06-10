
using Guestline.Battleships.Console;
using Guestline.Battleships.Game;
using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Infrastructure;
using Guestline.Battleships.Services;

using Microsoft.Extensions.DependencyInjection;

Instruction.Print();

using var dependencyInjectionResolver = new DependencyInjectionResolver(new ServiceCollection());
dependencyInjectionResolver.RegisterSingleton<IInteractionService, ConsoleService>();
IServiceProvider serviceProvider = dependencyInjectionResolver.RegisterCommon();

var gameFactory = serviceProvider.GetService<IGameFactory>();
Game game = gameFactory.Create();
game.Play();

Console.ReadKey();
