using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Entities.Base;
using Guestline.Battleships.Web.Services.Base;

using System.Text.Json;

namespace Guestline.Battleships.Web.Services
{
    internal class BoardSerializer : IBoardSerializer
    {
        public string Serialize(Board board)
        {
            string[,] numberedBoard = new string[10,10];
            int rowIndex = 0;
            foreach (IEnumerable<IReadOnlyCell> row in board)
            {
                int columnIndex = 0;
                foreach (IReadOnlyCell column in row)
                {
                    numberedBoard[rowIndex, columnIndex] = column.GetStatus().Name;
                    columnIndex++;
                }
                rowIndex++;
            }
            return JsonSerializer.Serialize(numberedBoard);
        }
    }
}
