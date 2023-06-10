using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Services
{
    public class SemaphoreService : ISemaphoreService
    {
        private TaskCompletionSource<string>? _tcs;

        public SemaphoreService()
        {
            _tcs = new TaskCompletionSource<string>();
        }

        public async Task<string> WaitUntilUserHit()
        {
            string result = await _tcs?.Task!;
            _tcs = new TaskCompletionSource<string>();

            return result;
        }

        public void Hit(string coordinates)
        {
            _tcs?.SetResult(coordinates);
        }
    }
}
