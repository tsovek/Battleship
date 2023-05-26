namespace Guestline.BattleshipGame.Domain.Entities
{
    public enum ShotResult // TODO: refactor to https://github.com/ardalis/SmartEnum
    {
        Unknown = 0,
        Miss = 1,
        Shot = 2,
        ShotAndSunk = 3,
        SunkAndWin = 4
    }
}
