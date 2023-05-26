namespace Guestline.BattleshipGame.Domain.Entities
{
    public enum ShotResult // refactor to SmartEnum!!!!
    {
        Unknown = 0,
        Miss = 1,
        Shot = 2,
        ShotAndSunk = 3,
        SunkAndWin = 4
    }
}
