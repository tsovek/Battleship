﻿namespace Guestline.Battleships.Domain
{
    internal class Constants
    {
        public const int BOARD_SIZE = 10;
        public const int FIRST_LETTER_ASCII = 65;
        public const int LAST_VALID_LETTER_ASCII = FIRST_LETTER_ASCII + BOARD_SIZE;
        public const int MAX_PLACEMENT_ITERATIONS = 1000;
    }
}
