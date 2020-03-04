using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Roulette.Bets
{
    class LowHigh : IBet
    {
        public string[] BetOptions { get; set; } = new[] {"low", "high"};
        public int CheckBet(string input, Bin bin)
        {
            int value = int.Parse(bin.BinValue());
            if (input == "low")
                return (value <= 18 && value >= 1) ? 1 : 0;
            
            return (value <= 38 && value >= 19) ? 1 : 0;
        }
    }
}
