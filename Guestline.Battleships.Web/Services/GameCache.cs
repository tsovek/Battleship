﻿using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Web.Services.Base;

namespace Guestline.Battleships.Game.Services
{
    public class GameCache : IGameCache
    {
        private readonly IGameFactory _gameFactory;

        private Game? _game;

        public GameCache(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Create() => _game = _gameFactory.Create();

        public Game? Get() => _game;
    }
}
