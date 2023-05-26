using Guestline.BattleshipGame.Exceptions;
using static Guestline.BattleshipGame.Domain.Entities.Constants;

namespace Guestline.BattleshipGame.Services
{
    internal class InputParser : IInputParser
    {
        public (char Column, int Row) Parse(string rawInput)
        {
            if (rawInput.Length == 0 || rawInput.Length > 3) throw new InvalidInputException(rawInput);
            
            char column = rawInput[0];
            if (IsColumnValid(column)) throw new InvalidInputException(rawInput);

            int row = ParseRowNumber(rawInput);
            if (row > 0 && row <= BOARD_SIZE)
            {
                return (rawInput[0], row);
            }
            throw new InvalidInputException(rawInput);
        }

        private bool IsColumnValid(char column) => column < FIRST_LETTER_ASCII || column > LAST_VALID_LETTER_ASCII;

        private int ParseRowNumber(string rawInput)
        {
            if (int.TryParse(rawInput.Substring(1, rawInput.Length - 1), out int row))
            {
                return row; 
            }
            return -1;
        }
    }
}
