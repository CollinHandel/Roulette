using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Bets
{
    class RedBlack : IBet
    {
        public string[] BetOptions { get; set; } = new[] {"red", "black", "r", "b"};
        public int CheckBet(string input, Bin bin)
        {
            if (input == "red") input = "r";
            else if (input == "black") input = "b";

            return (input == bin.BinColor().ToString().ToLower()) ? 1 : 0;
        }
    }
}
