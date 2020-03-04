using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Bets
{
    class NumberBet : IBet
    {
        public string[] BetOptions { get; set; }

        public NumberBet()
        {
            BetOptions = new string[BinValues.Values.Length];
            for (int i = 0; i < BinValues.Values.Length; i++)
            {
                BetOptions[i] = BinValues.Values[i];
            }
        }

        public int CheckBet(string input, Bin bin)
        {
            return (input == bin.BinValue()) ? 1 : 0;
        }
    }
}
