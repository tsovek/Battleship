using Guestline.Battleships.Domain.Entities;

using System.Text;

namespace Guestline.Battleships.Console
{
    internal static class Instruction
    {
        public static void Print()
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

            System.Console.WriteLine(sb.ToString());
        }
    }
}
