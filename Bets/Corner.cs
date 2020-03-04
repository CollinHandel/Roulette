using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roulette.Bets
{
    class Corner : IBet
    {
        public string[] BetOptions { get; set; }

        public Corner()
        {
            List<string> tempList = new List<string>();

            for (int i = 0; i < 33; i++)
            {
                if (i % 3 == 0) continue;

                tempList.Add($"{i},{i+1},{i+3},{i+4}");
            }

            BetOptions = new string[tempList.Count];

            for (int i = 0; i < tempList.Count; i++)
            {
                BetOptions[i] = tempList[i];
            }
        }

        public int CheckBet(string input, Bin bin)
        {
            int[] numbers = new int[4];
            int commaIndex;
            string temp = input;

            for (int i = 0; i < 4; i++)
            {
                if (i != 3)
                {
                    commaIndex = temp.IndexOf(',');
                    numbers[i] = int.Parse(temp.Substring(0, commaIndex));
                    temp = temp.Remove(0, commaIndex + 1);
                }
                else
                {
                    numbers[i] = int.Parse(temp);
                }
            }

            return (numbers.Contains(int.Parse(bin.BinValue()))) ? 1 : 0;
        }
    }
}
