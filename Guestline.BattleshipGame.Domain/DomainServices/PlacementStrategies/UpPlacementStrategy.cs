using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.BattleshipGame.Domain.DomainServices.Strategies
{
    internal class UpPlacementStrategy : PlacementStrategy
    {
        public override bool TryPlaceWarship(Cell[,] grid, Warship warship, int firstRow, int column)
        {
            if (firstRow - warship.CellsToOccupy < 0) return false;

            int lastRow = firstRow - warship.CellsToOccupy + 1;
            for (int row = firstRow; row >= lastRow; row--)
            {
                if (grid[row, column].Warship != null) return false;
                if (IsColumnOnTheLeftOccupied(grid, row, column)) return false;
                if (IsColumnOnTheRightOccupied(grid, row, column)) return false;
                if (row == firstRow && IsRowAboveOccupied(grid, row, column)) return false;
                if (row == lastRow && IsRowBelowOccupied(grid, row, column)) return false;
            }
            for (int row = firstRow; row >= lastRow; row--)
            {
                grid[row, column].Warship = warship;
            }

            return true;
        }
    }
}
