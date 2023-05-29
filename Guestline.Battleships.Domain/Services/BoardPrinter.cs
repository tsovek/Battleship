using System.Text;
using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Entities.Base;
using Guestline.Battleships.Domain.Services.Base;
using static Guestline.Battleships.Domain.Constants;

namespace Guestline.Battleships.Domain.Services
{
    public class BoardPrinter : IBoardPrinter
    {
        public string Print(Board board)
        {
            var sb = new StringBuilder();
            PrintHeader(sb);

            int rowNumber = 1;
            foreach (IEnumerable<IReadOnlyCell> row in board)
            {
                PrintLeftLegend(sb, rowNumber);
                foreach (IReadOnlyCell cell in row)
                {
                    char sign = cell.GetStatus().Symbol;
                    sb.Append(sign);
                    sb.Append(' ');
                }
                sb.AppendLine();
                rowNumber++;
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

        private void PrintLeftLegend(StringBuilder sb, int rowNumber)
        {
            sb.Append($"{rowNumber}  ");
            if (IsOneDigitNumber(rowNumber)) sb.Append(" ");
        }

        private bool IsOneDigitNumber(int rowNumber) 
            => rowNumber.ToString().Length == 1;
    }
}
