﻿using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Commands.Handlers
{
    public class HitCommandHandler : IHitCommandHandler
    {
        private readonly ISemaphoreService _semaphoreService;

        public HitCommandHandler(ISemaphoreService semaphoreService)
        {
            _semaphoreService = semaphoreService;
        }

        public void Handle(HitCommand command)
        {
            _semaphoreService.Hit(command.Coordinates);
        }
    }
}
