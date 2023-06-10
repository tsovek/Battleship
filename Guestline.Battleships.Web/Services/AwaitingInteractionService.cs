using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Web.Services
{
    public class AwaitingInteractionService : IInteractionService
    {
        private readonly ISemaphoreService _semaphoreService;

        public AwaitingInteractionService(ISemaphoreService semaphoreService)
        {
            _semaphoreService = semaphoreService;
        }

        public Task Output(string? message)
        {
            return Task.CompletedTask;
        }

        public Task Output(Board board)
        {
            return Task.CompletedTask;
        }

        public async Task<string> ReadInput()
        {
            return await _semaphoreService.WaitUntilUserHit();
        }
    }
}
