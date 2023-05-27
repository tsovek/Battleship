using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Exceptions;

namespace Guestline.BattleshipGame.Domain.ValueObjects
{
    public class Column
    {
        public char Value { get; }

        internal int IterableChar => Value - Constants.FIRST_LETTER_ASCII;

        private Column(char value) => Value = value;

        public static Column From(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new InvalidInputException("empty line");
            if (input.Length > 3) throw new InvalidInputException(input);

            char column = input[0];
            if (IsColumnValid(column) == false) throw new InvalidInputException(input);

            return new Column(column);
        }

        private static bool IsColumnValid(char column) => 
            column >= Constants.FIRST_LETTER_ASCII && column <= Constants.LAST_VALID_LETTER_ASCII;

    }
}
