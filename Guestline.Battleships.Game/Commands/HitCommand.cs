namespace Guestline.Battleships.Game.Commands
{
    public class HitCommand
    {
        public Guid GameId { get; set; }
        public string Coordinates { get; set; }
    }
}
