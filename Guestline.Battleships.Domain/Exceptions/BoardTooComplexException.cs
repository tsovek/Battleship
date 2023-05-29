namespace Guestline.Battleships.Domain.Exceptions
{
    public class BoardTooComplexException : BattleshipException
    {
        public BoardTooComplexException()
            : base("The board is too complex. Try to limit warships.")
        { }
    }
}
