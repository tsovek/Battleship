using Guestline.BattleshipGame.Domain.DomainServices.Strategies;

namespace Guestline.BattleshipGame.Domain.Entities
{
    public class Board
    {
        private readonly Cell[,] _grid;
        private readonly List<Warship> _warships;

        internal Board()
        {
            _grid = CreateEmptyGrid();
            _warships = new List<Warship>();
        }

        public ShotResult TryShot(int row, int column)
        {
            ShotResult shotResult = _grid[row, column].Reveal();
            if (shotResult == ShotResult.ShotAndSunk && _warships.All(w => w.IsSunk()))
            {
                return ShotResult.SunkAndWin;
            }

            return shotResult;
        }

        public void Surrender()
        {
            foreach (var cell in _grid)
            {
                cell.Reveal(forceReveal: true);
            }
        }

        internal ShotResult GetCellStatus(int row, int column) => _grid[row, column].GetStatus();

        internal bool TryPlaceWarship(PlacementStrategy placementStrategy, Warship warship,
            int rowStart, int columnStart)
        {
            bool placementResult = placementStrategy.TryPlaceWarship(_grid, warship, rowStart, columnStart);
            if (placementResult)
            {
                _warships.Add(warship);
            }

            return placementResult;
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
    }
}