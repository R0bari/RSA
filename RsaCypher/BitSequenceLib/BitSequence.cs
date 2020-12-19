using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace RsaCypher.BitSequenceLib
{
    public class BitSequence
    {
        public List<Bit> Bits { get; private set; } = new List<Bit>();

        public BitSequence() {}
        public BitSequence(params Bit[] bits)
        {
            this.Bits.AddRange(bits);
        }
        public BitSequence(params Byte[] bytes)
        {
            foreach (Byte currentByte in bytes)
            {
                this.Bits.AddRange(currentByte.Bits);
            }
        }
        public BitSequence(int number)
        {
            while (number > 0)
            {
                this.Bits.Add(new Bit(number % 2 != 0));
                number /= 2;
            }
        }
        public BitSequence (string line)
        {
            foreach (char symbol in line)
            {
                Byte currentByte = new Byte(symbol);
                this.Bits.AddRange(currentByte.Bits);
            }
        }
        public BitSequence SubSequence(int from, int to)
        {
            if (to < from)
            {
                return new BitSequence();
            }
            List<Bit> bits = new List<Bit>();
            for (int i = from; i < to; ++i)
            {
                bits.Add(this.Bits[i]);
            }
            return new BitSequence(bits);
        }
        public BitSequence(List<Bit> bits)
        {
            this.Bits.AddRange(bits);
        }
            public BitSequence(BigInteger bigNumber)
        {
            while (bigNumber > 0)
            {
                this.Bits.Add(new Bit(bigNumber % 2 != 0));
                bigNumber /= 2;
            }
            while (this.Bits.Count % 8 != 0)
            {
                this.Bits.Add(new Bit());
            }
        }

        public BigInteger ToBigInteger()
        {
            BigInteger number = new BigInteger();
            for (int i = 0; i < this.Bits.Count; ++i)
            {
                number += (BigInteger)(this.Bits[i].ToInt() * Math.Pow(2, i));
            }
            return number;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Bits.Count; i += 8)
            {
                result.Append(new Byte(SubSequence(i, i + 8)));
            }
            return result.ToString();
        }
    }
}
