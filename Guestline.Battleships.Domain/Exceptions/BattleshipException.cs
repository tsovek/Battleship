namespace Guestline.Battleships.Domain.Exceptions
{
    public class BattleshipException : Exception
    {
        public BattleshipException(string message) : base(message)
        { }
    }
}
