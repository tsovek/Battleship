using Guestline.Battleships.Domain.Services;
using Guestline.Battleships.Services;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Game;
using Guestline.Battleships.Game.Base;

using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Guestline.Battleships.Domain.Entities;

var services = new ServiceCollection();
services.AddTransient<IBoardService, BoardService>();
services.AddTransient<IBoardPrinter, BoardPrinter>();
services.AddTransient<IRandomService, RandomService>();
services.AddTransient<IInteractionService, ConsoleService>();
services.AddSingleton<IGameLoop, GameLoop>();
services.AddSingleton<Game>();
var serviceProvider = services.BuildServiceProvider();

PrintInstructionAndLegend();

var game = serviceProvider.GetService<Game>();
game.Play();

Console.ReadKey();

if (serviceProvider is IDisposable disposable)
{
    disposable.Dispose();
}

static void PrintInstructionAndLegend()
{
    var sb = new StringBuilder();

    sb.AppendLine("This is Battleships game!");
    sb.AppendLine("The grid is hardcoded (10x10). Find one Battleship (5 cells) and two Destroyers (4 cells) to win.");
    sb.AppendLine("Letters A-J are columns (capital), numbers 1-10 are rows, i.e. B9.");
    sb.AppendLine("Type special command `surrender` to end the game and print warships' positions.");
    sb.AppendLine();
    sb.AppendLine("Legend on the board:");
    
    foreach (var attemptResult in AttemptResult.GetAll())
    {
        sb.AppendLine($"{attemptResult.Name}: {attemptResult.Symbol}");
    }
    sb.AppendLine();

    Console.Write(sb.ToString());
}
