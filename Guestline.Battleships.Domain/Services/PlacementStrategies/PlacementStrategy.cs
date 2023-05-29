using Guestline.Battleships.Domain;
using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Domain.Services.PlacementStrategies
{
    internal abstract class PlacementStrategy
    {
        public static PlacementStrategy Create(Direction direction)
        {
            return direction switch
            {
                Direction.Left => new LeftPlacementStrategy(),
                Direction.Right => new RightPlacementStrategy(),
                Direction.Down => new DownPlacementStrategy(),
                Direction.Up => new UpPlacementStrategy(),
                _ => throw new InvalidOperationException("Unknown direction"),
            };
        }

        public abstract bool TryPlaceWarship(Cell[,] grid, Warship warship, int rowStart, int columnStart);

        protected bool IsColumnOnTheLeftOccupied(Cell[,] grid, int row, int column)
        {
            return column != 0 && grid[row, column - 1].Warship != null;
        }

        protected bool IsColumnOnTheRightOccupied(Cell[,] grid, int row, int column)
        {
            return column != Constants.BOARD_SIZE - 1 && grid[row, column + 1].Warship != null;
        }

        protected bool IsRowAboveOccupied(Cell[,] grid, int row, int column)
        {
            if (row == 0) return false;
            return grid[row - 1, column].Warship != null;
        }

        protected bool IsRowBelowOccupied(Cell[,] grid, int row, int column)
        {
            if (row == Constants.BOARD_SIZE - 1) return false;
            return grid[row + 1, column].Warship != null;
        }
    }
}
