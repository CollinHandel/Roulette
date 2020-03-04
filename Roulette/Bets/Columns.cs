using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Bets
{
    class Columns : IBet
    {
        public string[] BetOptions { get; set; } = {"first", "second", "third"};
        public int CheckBet(string input, Bin bin)
        {
            int value = int.Parse(bin.BinValue());
            switch (input)
            {
                case "first":
                    return (value % 3 == 0) ? 1 : 0;
                case "second":
                    return ((value + 1) % 3 == 0) ? 1 : 0;
                default:
                    return ((value - 1) % 3 == 0) ? 1 : 0;
            }
        }
    }
}
