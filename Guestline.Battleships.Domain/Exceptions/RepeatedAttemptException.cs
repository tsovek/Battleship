namespace Guestline.Battleships.Domain.Exceptions
{
    public class RepeatedAttemptException : BattleshipException
    {
        public RepeatedAttemptException() : base("You already attempted this cell.") { }
    }
}
