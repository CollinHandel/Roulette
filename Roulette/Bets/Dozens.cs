using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Bets
{
    class Dozens : IBet
    {
        public string[] BetOptions { get; set; } = new [] {"1-12", "13-24", "25-36"};
        public int CheckBet(string input, Bin bin)
        {
            int value = int.Parse(bin.BinValue());
            if (input == "1-12")
                return (value <= 12 && value >= 1) ? 1 : 0;
            else if (input == "13-24")
                return (value <= 24 && value >= 13) ? 1 : 0;
            else
                return (value <= 36 && value >= 25) ? 1 : 0;
        }
    }
}
