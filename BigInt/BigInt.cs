using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBigInt
{
    public class BigInt
    {
        private List<int> _digitBlocks;
        public int Length { get { return _digitBlocks.Count; } }
        public int BlockSize { get; private set; }
        public bool IsPositive { get; }

        public BigInt() { }
        public BigInt(string number, int blockSize)
        {
            _digitBlocks = new List<int>();
            BlockSize = blockSize;
            if (!IsDigitArray(number))
            {
                throw new Exception("Current string contains not only digits.");
            }
            int digitCounter = 0;
            while (number != "")
            {
                int currentDigit = int.Parse(number[number.Length - 1].ToString());
                if (digitCounter % BlockSize == 0)
                {
                    digitCounter = 0;
                    _digitBlocks.Add(currentDigit);
                } 
                else
                {
                    _digitBlocks[_digitBlocks.Count - 1] += currentDigit * (int)Math.Pow(10, digitCounter);
                }
                ++digitCounter;
                number = number.Substring(0, number.Length - 1);
            }

        }
        private bool IsDigitArray(string number)
        {
            foreach (char symbol in number) {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(BigInt anotherNumber)
        {
            int maxLength = this.Length > anotherNumber.Length ? this.Length : anotherNumber.Length;

            for (int i = 0; i < maxLength; ++i)
            {
                if (i < this.Length)
                {
                    _digitBlocks[i] += anotherNumber._digitBlocks[i];
                } 
                else
                {
                    _digitBlocks.Add(anotherNumber._digitBlocks[i]);
                }
            }

            this.Normalise();
        }

        private void Normalise()
        {
            int maxBlockValue = (int)Math.Pow(10, BlockSize + 1) - 1;
            int remainder = default;
            for (int i = 0; i < this.Length || this._digitBlocks[this._digitBlocks.Count - 1] > maxBlockValue; ++i)
            {
                if (this._digitBlocks[i] > maxBlockValue)
                {
                    remainder = this._digitBlocks[i] - maxBlockValue;
                    if (i < this._digitBlocks.Count - 1)
                    {
                        this._digitBlocks[i + 1] += remainder;
                    } else
                    {
                        this._digitBlocks.Add(remainder);
                    }
                }
            }
        }

        public bool IsGreater(BigInt anotherNumber)
        {
            if (this.IsPositive && !anotherNumber.IsPositive)
            {
                return true;
            }
            return this.IsPositive
                ? this.ToString().Length > anotherNumber.ToString().Length
                : this.ToString().Length < anotherNumber.ToString().Length;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is BigInt))
            {
                return false;
            }
            BigInt bigInt = (BigInt)obj;
            return bigInt.IsPositive == this.IsPositive &&
                bigInt.BlockSize == this.BlockSize &&
                bigInt._digitBlocks.Equals(this._digitBlocks);
        }
        public override int GetHashCode()
        {
            return IsPositive.GetHashCode() + BlockSize.GetHashCode() + IsPositive.GetHashCode() + _digitBlocks.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder resultNumber = new StringBuilder();
            foreach (int currentBlock in _digitBlocks.Reverse<int>().ToList())
            {
                resultNumber.Append(currentBlock);
            }
            return resultNumber.ToString();
        }
    }
}
