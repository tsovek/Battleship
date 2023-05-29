using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;

namespace Guestline.Battleships.Domain.ValueObjects
{
    public record Row
    {
        public int Value { get; }

        private Row(int value) => Value = value; 

        public static Row From(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new InvalidInputException("empty line");
            if (input.Length > 3) throw new InvalidInputException(input);

            int row = ParseRowNumber(input);
            if (row > 0 && row <= Constants.BOARD_SIZE)
            {
                return new Row(row);
            }
            throw new InvalidInputException(input);
        }

        internal int IterableValue => Value - 1;

        private static int ParseRowNumber(string rawInput)
        {
            if (int.TryParse(rawInput.Substring(1, rawInput.Length - 1), out int row))
            {
                return row;
            }
            return -1;
        }
    }
}
