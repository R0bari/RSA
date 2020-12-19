using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCypher.BitSequenceLib
{
    public class Bit
    {
        public bool Value { get; private set; }

        public Bit(bool value = false) => Value = value;
        public Bit(Bit otherBit) => Value = otherBit.Value;
        public Bit Xor(Bit otherBit) => new Bit(Value ^ otherBit.Value);
        public override string ToString() => Value ? "1" : "0";
        public int ToInt() => Value ? 1 : 0;
    }
}
