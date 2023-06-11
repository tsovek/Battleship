namespace Guestline.Battleships.Game.Services.Base
{
    public interface IGameCache
    {
        Game Get();
        void Create();
    }
}
