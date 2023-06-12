namespace Guestline.Battleships.Web.Commands
{
    public class HitCommand
    {
        public Guid GameId { get; set; }
        public string? Coordinates { get; set; }
    }
}
