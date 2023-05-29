namespace Guestline.Battleships.Domain.Entities
{
    public class Battleship : Warship
    {
        internal override int CellsToOccupy => 5;
    }
}
