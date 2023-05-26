namespace Guestline.BattleshipGame.Domain.Entities
{
    public class Battleship : Warship
    {
        internal override int CellsToOccupy => 5;
    }
}
