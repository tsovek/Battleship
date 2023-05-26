namespace Guestline.BattleshipGame.Services
{
    public interface IInputParser
    {
        (char Column, int Row) Parse(string rawInput);
    }
}
