using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Bets
{
    public class EvenOdd : IBet
    {
        public string[] BetOptions { get; set; } = new[] {"even", "odd"};

        public int CheckBet(string input, Bin bin)
        {
            if (input == "even")
                return (int.Parse(bin.BinValue()) % 2 == 0) ? 1 : 0;
            else
                return (int.Parse(bin.BinValue()) % 2 == 1) ? 1 : 0;
        }
    }
}
