using Guestline.Battleships.Domain.Entities;
using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.ValueObjects;
using Guestline.Battleships.Game.Services.Base;

namespace Guestline.Battleships.Game.Services
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IInteractionService _interactionService;

        public GameLoop(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        public async Task Loop(Board board)
        {
            while (board.GameOver() == false)
            {
                string? rawInput = await _interactionService.ReadInput();

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

                        await _interactionService.Output(attemptResult.Name);
                    }

                    await _interactionService.Output(board);
                }
                catch (BattleshipException e)
                {
                    await _interactionService.Output(e.Message);
                }
            }
        }

        private bool GiveUp(string? rawInput) => rawInput == "surrender";
    }
}
