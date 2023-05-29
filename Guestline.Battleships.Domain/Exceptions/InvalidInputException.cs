namespace Guestline.Battleships.Domain.Exceptions
{
    public class InvalidInputException : BattleshipException
    {
        public InvalidInputException(string input) 
            : base($"Invalid input: {input}. Try some correct one.")
        { }
    }
}
