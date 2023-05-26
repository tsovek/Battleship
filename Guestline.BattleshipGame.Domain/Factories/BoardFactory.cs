using Guestline.BattleshipGame.Domain.Entities;
using Guestline.BattleshipGame.Domain.Services;

using System.Data.Common;

namespace Guestline.BattleshipGame.Domain.Factories
{
    public partial class BoardFactory : IBoardFactory
    {
        public Board Create()
        {
            return new Board();
        }
    }
}