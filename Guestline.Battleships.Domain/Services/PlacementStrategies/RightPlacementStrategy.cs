﻿using Guestline.Battleships.Domain;
using Guestline.Battleships.Domain.Entities;

namespace Guestline.Battleships.Domain.Services.PlacementStrategies
{
    internal class RightPlacementStrategy : PlacementStrategy
    {
        public override bool TryPlaceWarship(Cell[,] grid, Warship warship, int row, int firstColumn)
        {
            if (warship.CellsToOccupy + firstColumn >= Constants.BOARD_SIZE) return false;

            int lastColumn = firstColumn + warship.CellsToOccupy - 1;
            for (int column = firstColumn; column <= lastColumn; column++)
            {
                if (grid[row, column].Warship != null) return false;
                if (IsRowAboveOccupied(grid, row, column)) return false;
                if (IsRowBelowOccupied(grid, row, column)) return false;
                if (column == firstColumn && IsColumnOnTheLeftOccupied(grid, row, column)) return false;
                if (column == lastColumn && IsColumnOnTheRightOccupied(grid, row, column)) return false;
            }
            for (int column = firstColumn; column <= lastColumn; column++)
            {
                grid[row, column].Warship = warship;
            }

            return true;
        }
    }
}
