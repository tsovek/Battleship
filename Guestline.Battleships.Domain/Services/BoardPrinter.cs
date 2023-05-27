using System.Text;
using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Entities.Base;
using Guestline.Battleships.Domain.Services.Base;
using static Guestline.BattleshipGame.Domain.Constants;

namespace Guestline.Battleships.Domain.Services
{
    public class BoardPrinter : IBoardPrinter
    {
        public string Print(Board board)
        {
            var sb = new StringBuilder();
            PrintHeader(sb);

            int i = 0;
            foreach (IEnumerable<IReadOnlyCell> row in board)
            {
                PrintLeftLegend(sb, i);
                foreach (IReadOnlyCell cell in row)
                {
                    char sign = cell.GetStatus().Symbol;
                    sb.Append(sign);
                    sb.Append(' ');
                }
                sb.AppendLine();
                i++;
            }

            return sb.ToString();
        }

        public string PrintLegend()
        {
            var sb = new StringBuilder();
            foreach (var attemptResult in AttemptResult.GetAll())
            {
                sb.AppendLine($"{attemptResult.Name}: {attemptResult.Symbol}");
            }
            return sb.ToString();
        }

        private void PrintHeader(StringBuilder sb)
        {
            sb.Append($"    ");
            for (int i = FIRST_LETTER_ASCII; i < LAST_VALID_LETTER_ASCII; i++)
            {
                sb.Append($"{(char)i} ");
            }
            sb.AppendLine();
        }

        private void PrintLeftLegend(StringBuilder sb, int row)
        {
            sb.Append($"{row + 1}  ");
            if (row != BOARD_SIZE - 1) sb.Append(" ");
        }
    }
}
