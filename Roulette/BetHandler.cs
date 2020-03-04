using System;
using System.Collections.Generic;
using System.Text;
using Roulette.Bets;

namespace Roulette
{
    class BetHandler
    {
        public IBet[] bets = {new EvenOdd(), new NumberBet(), new RedBlack(), 
                              new LowHigh(), new Dozens(), new Columns(), new Street(),
                              new SixNumbers(), new Split(), new Corner() };

        public int HandleBet(string chosenBet, Bin selectedBin)
        {
            // Only returns 0 (lose) or 1 (win)
            foreach (var bet in bets)
            {
                foreach (var option in bet.BetOptions)
                {
                    if (option == chosenBet)
                    {
                        return bet.CheckBet(chosenBet, selectedBin);
                    }
                }
            }

            // Returns 2 for invalid bet
            return 2;
        }
    }
}
