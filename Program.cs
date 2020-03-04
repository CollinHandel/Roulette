using System;
using System.Globalization;
using System.Net.Mime;
using System.Threading.Channels;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            AllBins allBins = new AllBins();
            BetHandler betHandler = new BetHandler();
            string bet;

            do
            {
                Console.WriteLine(RouletteBetDisplay());
                Console.WriteLine("Valid Bets:");
                Console.WriteLine("- To bet a specific bin, only put the number (not color)");
                Console.WriteLine("- Even or Odd");
                Console.WriteLine("- Red or Black");
                Console.WriteLine("- Low or High");
                Console.WriteLine("- Valid Dozens Bet Options: 1-12    13-24    25-36");
                Console.WriteLine("- Columns:    First    Second    Third");
                Console.WriteLine("- Street: Input St(the street number referred above)");
                Console.WriteLine("- 6 Numbers: (street number),(street number)");
                Console.WriteLine("- Split: Input Split(number),(number)");
                Console.WriteLine("- Corner: Start with the lower number and progress to the largest separated by commas.  1,2,4,5");

                var selectedBin = SpinWheel(allBins);
                int input = 0; 
                do
                {
                    Console.WriteLine();
                    if (input == 2) Console.WriteLine("Bet was invalid! Try again");

                    Console.WriteLine("Insert your bet or type 'Quit':");
                    bet = Console.ReadLine();

                    if (bet == "quit" || bet == null) Environment.Exit(0);
                    else
                        input = betHandler.HandleBet(bet.ToLower(), selectedBin);
                } while (input == 2);

                DrawSpinAnimation(allBins, selectedBin);

                Console.WriteLine(input == 1 ? "Your bet won!" : "Your bet lost!");

                Console.WriteLine($"Your Bet: {bet}   |   Selected Bin: {selectedBin.BinValue()}{selectedBin.BinColor()}");
                Console.WriteLine("\n\nPress enter to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (bet != "quit");
        }



        static Bin SpinWheel(AllBins allBins)
        {
            return allBins.SelectedBin();
        }



        static string RouletteBetDisplay()
        {
            return "St: 1  2  3   4   5   6   7   8   9   10  11  12\n" +
                   "--------------------------------------------------------\n" +
                   "|00|3R|6B|9R|12R|15B|18R|21R|24B|27R|30R|33B|36R| 2To1 |\n" +
                   "|--|2B|5R|8B|11B|14R|17B|20B|23R|26B|29B|32R|35B| 2To1 |\n" +
                   "|0 |1R|4B|7R|10B|13B|16R|19R|22B|25R|28B|31B|34R| 2To1 |\n" +
                   "--------------------------------------------------------\n" +
                   "   |   1st 12   |     2nd 12    |     3rd 12    |\n" +
                   "   ----------------------------------------------\n" +
                   "   | 1To18 | EVEN  | RED | BLACK | ODD | 19To36 |\n" +
                   "   ----------------------------------------------";
        }



        static void DrawSpinAnimation(AllBins allBins, Bin selectedBin)
        {

            Bin[] bins = allBins.ReturnAllBins();

            for (int i = 0; i < allBins.ReturnIndex(selectedBin); i++)
            {
                Console.Clear();

                for (int j = 0; j < bins.Length; j++)
                {
                    if (bins[j].BinValue().Length == 1)
                        Console.Write(" ");

                    Console.Write($"{bins[j].BinValue()}{bins[j].BinColor()}");

                    if (j != bins.Length - 1)
                    {
                        Console.Write(",");
                    }
                }

                Console.WriteLine();
                
                int numOfSpaces = 1 + ((i * 4) + 4);

                for (int j = 0; j < numOfSpaces; j++)
                {
                    Console.Write(" ");
                }

                Console.Write("O");

                System.Threading.Thread.Sleep(150);

            }

            Console.Write("\n\n");
            Console.WriteLine(RouletteBetDisplay());
        }
    }
}
