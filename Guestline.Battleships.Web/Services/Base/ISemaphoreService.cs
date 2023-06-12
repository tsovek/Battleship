namespace Guestline.Battleships.Web.Services.Base
{
    public interface ISemaphoreService
    {
        Task<string> WaitUntilUserHit();
        void Hit(string coordinates);
        void Cancel();
    }
}
