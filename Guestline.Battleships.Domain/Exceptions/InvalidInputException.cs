using Guestline.BattleshipGame.Domain.Exceptions;

namespace Guestline.BattleshipGame.Domain.Exceptions
{
    internal class InvalidInputException : BattleshipException
    {
        public InvalidInputException(string input) 
            : base($"Invalid input: {input}. Try some correct one.")
        { }
    }
}
