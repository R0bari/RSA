using System;
using System.Collections.Generic;
using System.Text;

namespace RsaCypher.BitSequenceLib
{
    public class Byte
    {
        public List<Bit> Bits { get; private set; } = new List<Bit>();

        public Byte(int dec)
        {
            Bit[] bits = new Bit[8];
            for (int i = 0; i < 8; ++i)
            {
                if (dec > 0)
                {
                    bits[i] = new Bit(dec % 2 != 0);
                    dec /= 2;
                    continue;
                }
                bits[i] = new Bit();
            }
            Bits.AddRange(bits);
        }
        public Byte(BitSequence bitSequence)
        {
            if (bitSequence.Bits.Count >= 8)
            {
                foreach (Bit bit in bitSequence.SubSequence(0, 8).Bits)
                {
                    Bits.Add(bit);
                }
            }
        }
        public override string ToString()
        {
            int symbolCode = 0;
            for (int i = 0; i < 8; ++i)
            {
                symbolCode += Bits[i].ToInt() * (int)Math.Pow(2, i);
            }
            char symbol = (char)symbolCode;
            return symbol.ToString();
        }
    }
}
