using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.BattleshipGame.Domain.DomainServices.Strategies
{
    internal class LeftPlacementStrategy : PlacementStrategy
    {
        public override bool TryPlaceWarship(Cell[,] grid, Warship warship,
            int row, int lastColumn)
        {
            if (lastColumn - warship.CellsToOccupy + 1 < 0) return false;

            int firstColumn = lastColumn - warship.CellsToOccupy + 1;
            for (int column = lastColumn; column >= firstColumn; column--)
            {
                if (grid[row, column].Warship != null) return false;
                if (IsRowAboveOccupied(grid, row, column)) return false;
                if (IsRowBelowOccupied(grid, row, column)) return false;
                if (column == firstColumn && IsColumnOnTheLeftOccupied(grid, row, column)) return false;
                if (column == lastColumn && IsColumnOnTheRightOccupied(grid, row, column)) return false;
            }
            for (int column = lastColumn; column >= firstColumn; column--)
            {
                grid[row, column].Warship = warship;
            }

            return true;
        }
    }
}
