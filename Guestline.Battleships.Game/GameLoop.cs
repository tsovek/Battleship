using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.ValueObjects;
using Guestline.Battleships.Game.Base;

namespace Guestline.Battleships.Game
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IInteractionService _interactionService;

        public GameLoop(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        public void Loop(Board board)
        {
            while (board.GameOver() == false)
            {
                string? rawInput = _interactionService.ReadInput();

                try
                {
                    if (GiveUp(rawInput))
                    {
                        board.Surrender();
                    }
                    else
                    {
                        var row = Row.From(rawInput);
                        var column = Column.From(rawInput);
                        AttemptResult attemptResult = board.TryHit(row, column);

                        _interactionService.Output(attemptResult.Name);
                    }

                    _interactionService.Output(board);
                }
                catch (BattleshipException e)
                {
                    _interactionService.Output(e.Message);
                }
            }
        }

        private bool GiveUp(string? rawInput) => rawInput == "surrender";
    }
}
