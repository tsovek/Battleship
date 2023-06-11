using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Entities.Base;
using Guestline.Battleships.Web.DTO;
using Guestline.Battleships.Web.Services.Base;

using System.Text.Json;

namespace Guestline.Battleships.Web.Services
{
    internal class BoardSerializer : IBoardSerializer
    {
        public string Serialize(Board board)
        {
            var items = new List<ItemDTO>();
            int rowIndex = 0;
            foreach (IEnumerable<IReadOnlyCell> row in board)
            {
                int columnIndex = 0;
                foreach (IReadOnlyCell column in row)
                {
                    items.Add(new ItemDTO 
                    { 
                        Row = rowIndex,
                        Column = columnIndex,
                        Value = column.GetStatus().Name
                    });
                    columnIndex++;
                }
                rowIndex++;
            }
            return JsonSerializer.Serialize(new BoardDTO { Items = items.ToArray() });
        }
    }
}
