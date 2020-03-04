using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Roulette.Bets
{
    class SixNumbers : IBet
    {
        public string[] BetOptions { get; set; }

        public SixNumbers()
        {
            BetOptions = new string[12];
            for (int i = 0; i < 11; i++)
            {
                BetOptions[i] = $"{i},{i + 1}";
            }
        }

        public int CheckBet(string input, Bin bin)
        {
            int commaIndex = input.IndexOf(',');
            int streetIndex1 = int.Parse(input.Substring(0, commaIndex));
            int streetIndex2 = int.Parse(input.Substring(commaIndex + 1));
            int[] street = new int[6];

            for (int i = 1; i <= 3; i++)
            {
                street[i - 1] = (streetIndex1 - 1) * 3 + i;
            }
            
            for (int i = 1; i <= 3; i++)
            {
                street[i + 2] = (streetIndex2 - 1) * 3 + i;
            }

            return (street.Contains(int.Parse(bin.BinValue()))) ? 1 : 0;
        }
    }
}
