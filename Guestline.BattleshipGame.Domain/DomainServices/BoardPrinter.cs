using System.Text;
using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Entities.Abstract;

using static Guestline.BattleshipGame.Domain.Constants;

namespace Guestline.BattleshipGame.Domain.DomainServices
{
    public class BoardPrinter : IBoardPrinter
    {
        private readonly Dictionary<ShotResult, char> _mappings = new Dictionary<ShotResult, char>
        {
            [ShotResult.Unknown] = ' ',
            [ShotResult.Miss] = 'x',
            [ShotResult.Shot] = 'c',
            [ShotResult.ShotAndSunk] = 'o',
        };

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
                    char sign = _mappings[cell.GetStatus()];
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
            foreach (var kvp in _mappings)
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value}");
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
