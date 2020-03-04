using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Bets
{
    class Split : IBet
    {
        public string[] BetOptions { get; set; }

        public Split()
        {
            List<string> tempList = new List<string>();

            for (int i = 0; i < 35; i++)
            {
                if (i % 3 != 0)
                    tempList.Add($"split{i},{i+1}");

                if (i < 34)
                    tempList.Add($"split{i},{i+3}");
            }

            BetOptions = new string[tempList.Count];

            for (int i = 0; i < tempList.Count; i++)
            {
                BetOptions[i] = tempList[i];
            }
        }

        public int CheckBet(string input, Bin bin)
        {
            int binValue = int.Parse(bin.BinValue());

            input = input.Replace("split", "");
            int commaIndex = input.IndexOf(',');

            var val1 = int.Parse(input.Substring(0, commaIndex));
            var val2 = int.Parse(input.Substring(commaIndex + 1));

            return (val1 == binValue || val2 == binValue) ? 1 : 0;
        }
    }
}
