using Guestline.Battleships.Web.Services.Base;

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
            if (_tcs?.Task.Status != TaskStatus.WaitingForActivation)
            {
                _tcs = new TaskCompletionSource<string>();
            }
            string result = await _tcs?.Task!;
            _tcs = new TaskCompletionSource<string>();

            return result;
        }

        public void Hit(string coordinates)
        {
            if (_tcs?.Task.Status != TaskStatus.WaitingForActivation)
            {
                return; // nothing is waiting for us.
            }
            _tcs?.SetResult(coordinates);
        }

        public void Cancel()
        {
            if (_tcs?.Task.Status == TaskStatus.RanToCompletion)
            {
                return; // nothing is waiting for us.
            }
            _tcs?.SetCanceled();
        }
    }
}
