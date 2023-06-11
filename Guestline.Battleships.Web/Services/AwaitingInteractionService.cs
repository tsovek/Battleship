using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Web.Hubs;
using Guestline.Battleships.Web.Services.Base;

using Microsoft.AspNetCore.SignalR;

namespace Guestline.Battleships.Web.Services
{
    public class AwaitingInteractionService : IInteractionService
    {
        private readonly ISemaphoreService _semaphoreService;
        private readonly IBoardSerializer _boardSerializer;
        private readonly IHubContext<BoardHub> _boardHub;
        private readonly IHubContext<MessageHub> _messageHub;

        public AwaitingInteractionService(
            ISemaphoreService semaphoreService,
            IBoardSerializer boardSerializer,
            IHubContext<BoardHub> boardHub,
            IHubContext<MessageHub> messageHub)
        {
            _semaphoreService = semaphoreService;
            _boardSerializer = boardSerializer;
            _boardHub = boardHub;
            _messageHub = messageHub;
        }

        public async Task Output(string? message)
        {
            await _messageHub.Clients.All.SendAsync("MessageUpdated", message ?? "Unknown");
        }

        public async Task Output(Board board)
        {
            string serializedBoard = _boardSerializer.Serialize(board);

            await _boardHub.Clients.All.SendAsync("BoardUpdated", serializedBoard);
        }

        public async Task<string> ReadInput()
        {
            return await _semaphoreService.WaitUntilUserHit();
        }
    }
}
