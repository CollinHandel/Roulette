using System;
using System.Drawing;

namespace Roulette
{
    class AllBins
    {
        private Bin[] _bins;
        // private string[] bins = {"0G", "1B", 

        private readonly Random _randomBinSelector = new Random();

        public AllBins()
        {
            _bins = new Bin[BinValues.Values.Length];

            for (int i = 0; i < BinValues.Values.Length; i++)
            {
                if (i == 0 || BinValues.Values[i] == "00")
                    this._bins[i] = new Bin(Colors.G, BinValues.Values[i]);
                else if (i % 2 == 0)
                    this._bins[i] = new Bin(Colors.R, BinValues.Values[i]);
                else
                    this._bins[i] = new Bin(Colors.B, BinValues.Values[i]);
            }
        }

        public Bin SelectedBin()
        {
            Bin bin = _bins[_randomBinSelector.Next(_bins.Length)];

            return bin;
        }

        public int ReturnIndex(Bin selectedBin)
        {
            return Array.IndexOf(_bins, selectedBin);
        }

        public Bin[] ReturnAllBins()
        {
            return _bins;
        }
    }
}
