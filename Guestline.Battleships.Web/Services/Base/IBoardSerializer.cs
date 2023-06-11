using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Web.Services.Base
{
    public interface IBoardSerializer
    {
        string Serialize(Board board);
    }
}
