using Guestline.BattleshipGame.Domain.Entities;

namespace Guestline.BattleshipGame
{
    internal static class Extensions
    {
        public static int ToColumnIndex(this char @char) => @char - Constants.FIRST_LETTER_ASCII;

        public static int ToRowIndex(this int row) => row - 1;
    }
}
