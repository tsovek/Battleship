namespace Guestline.BattleshipGame.Domain.Exceptions
{
    public class PlacementIterationLimitExceededException : BattleshipException
    {
        public PlacementIterationLimitExceededException()
            : base("Couldn't place warship in satisfied iteration limit. Check whether your board is not too complex.")
        { }
    }
}
