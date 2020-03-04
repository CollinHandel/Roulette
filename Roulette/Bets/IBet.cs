using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Bets
{
    interface IBet
    {
        public string[] BetOptions { get; set; }

        public int CheckBet(string input, Bin bin);
    }
}
