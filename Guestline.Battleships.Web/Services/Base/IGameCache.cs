namespace Guestline.Battleships.Web.Services.Base
{
    public interface IGameCache
    {
        Game.Game? Get();
        void Create();
    }
}
