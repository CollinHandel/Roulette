using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roulette.Bets
{
    class Street : IBet
    {
        public string[] BetOptions { get; set; }

        public Street()
        {
            BetOptions = new string[12];
            for (int i = 0; i < 12; i++)
            {
                BetOptions[i] = $"st{i + 1}";
            }
        }

        public int CheckBet(string input, Bin bin)
        {
            int streetIndex = int.Parse(input.Substring(input.Length - 1));
            int[] street = new int[3];

            for (int i = 1; i <= 3; i++)
            {
                street[i - 1] = (streetIndex - 1) * 3 + i;
            }

            return (street.Contains(int.Parse(bin.BinValue()))) ? 1 : 0;
        }
    }
}
