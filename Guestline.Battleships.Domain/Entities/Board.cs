using System.Collections;
using Guestline.BattleshipGame.Domain.Entities.Base;
using Guestline.BattleshipGame.Domain.ValueObjects;
using Guestline.Battleships.Domain.Services.PlacementStrategies;

namespace Guestline.BattleshipGame.Domain.Entities
{
    public class Board : IEnumerable<IEnumerable<IReadOnlyCell>>
    {
        private readonly Cell[,] _grid;
        private readonly List<Warship> _warships;

        public Board()
        {
            _grid = CreateEmptyGrid();
            _warships = new List<Warship>();
        }

        public AttemptResult TryHit(Row row, Column column)
        {
            return _grid[row.IterableValue, column.IterableChar].Reveal();
        }

        public bool GameOver() => _warships.All(w => w.IsSunk());

        public void Surrender()
        {
            foreach (var cell in _grid)
            {
                cell.ForceReveal();
            }
        }

        IEnumerator<IEnumerable<IReadOnlyCell>> IEnumerable<IEnumerable<IReadOnlyCell>>.GetEnumerator()
        {
            return GetEnumerableGrid().GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerableGrid().GetEnumerator();
        }

        internal bool TryPlaceWarship(PlacementStrategy placementStrategy, Warship warship,
            int rowStart, int columnStart)
        {
            bool success = placementStrategy.TryPlaceWarship(_grid, warship, rowStart, columnStart);
            if (success)
            {
                _warships.Add(warship);
            }

            return success;
        }

        private Cell[,] CreateEmptyGrid()
        {
            int size = Constants.BOARD_SIZE;
            var grid = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = new Cell();
                }
            }
            return grid;
        }

        private IEnumerable<IEnumerable<IReadOnlyCell>> GetEnumerableGrid()
        {
            var result = new List<List<IReadOnlyCell>>();
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                var row = new List<IReadOnlyCell>();
                for (int j = 0; j < Constants.BOARD_SIZE; j++)
                {
                    row.Add(_grid[i, j]);
                }
                result.Add(row);
            }
            return result;
        }
    }
}