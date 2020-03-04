using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Roulette
{
    public class Bin
    {
        private readonly Colors color;
        private readonly string value;

        public Bin(Colors _color, string _value)
        {
            color = _color;
            value = _value;
        }

        public override string ToString() => $"{this.value}{this.color}";

        public Colors BinColor() => this.color;

        public string BinValue() => this.value;
    }
}
