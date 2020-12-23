using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using RsaCypher.BitSequenceLib;

namespace RsaCypher
{
    public class RSA : ICypher
    {
        /// <summary>
        /// Neccessary constant required to init keys.
        /// To init open key pair and closed key pair required  
        /// initialising "P" and "Q" and then calling method "Init"
        /// </summary>
        public BigInteger P { get; set; }
        /// <summary>
        /// Neccessary constant required to init keys.
        /// To init open key pair and closed key pair required  
        /// initialising "P" and "Q" and then calling method "Init"
        /// </summary>
        public BigInteger Q { get; set; }
        public BigInteger M { get; set; }
        /// <summary>
        /// "e" in open key pair - [e; n] 
        /// </summary>
        public BigInteger FirstPartOpenKey { get; set; }
        /// <summary>
        /// "d" in closed key pair - [d; n]
        /// </summary>
        public BigInteger FirstPartClosedKey { get; set; }
        /// <summary>
        /// "n" in open key pair - [e; n] and in closed key pair [d; n]
        /// </summary>
        public BigInteger SecondPartKey { get; set; }

        //  FirstPartOfClosedKey - e, FirstPartOfOpenKey - d
        //  SecondPartOfKey - n
        //  [e; n] - open key pair, [d; n] - closed key pair
        public RSA() { }
        public RSA(BigInteger p, BigInteger q)
        {
            Init(p, q);
        }
        public void Init(BigInteger p, BigInteger q)
        {
            P = p;
            Q = q;
            Init();
        }
        public void Init()
        {
            M = (P - 1) * (Q - 1);
            SecondPartKey = P * Q;
            FirstPartOpenKey = CalculateE(M);
            FirstPartClosedKey = CalculateD(FirstPartOpenKey, M);
        }
        private BigInteger CalculateE(BigInteger m)
        {
            int e = 2;
            while (m % e == 0)
            {
                do
                {
                    ++e;
                } while (!isPrime(e));
            }

            bool isPrime(int number)
            {
                for (int i = 2; i < Math.Sqrt(number); ++i)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            return new BigInteger(e);
        }
        private BigInteger CalculateD(BigInteger e, BigInteger m)
        {
            BigInteger d = m / e + 1;
            BigInteger de = d * e;
            BigInteger _m = new BigInteger(m.ToByteArray());

            while (de - _m != 1)
            {
                _m += m;
                de += e * ((_m - de) / e + 1);
            }
            d = de / e;
            return d;
        }
        public string Encrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder();

            while (message.Length % 8 != 0)
            {
                message += " ";
            }

            foreach (char symbol in message)
            {
                BigInteger resultNumber = BigInteger.ModPow(new BigInteger(symbol), FirstPartOpenKey, SecondPartKey);

                string zeros = "";
                for (int i = 0; i < 16 - resultNumber.ToString().Length; ++i)
                {
                    zeros += "0";
                }
                encryptedMessage.Append(zeros + resultNumber.ToString() + " ");
            }
            return encryptedMessage.ToString();
        }
        public BigInteger Encrypt(BigInteger numberToEncrypt)
        {
            return BigInteger.ModPow(numberToEncrypt, FirstPartOpenKey, SecondPartKey);
        }
        public string Decrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            string[] messageBlocks = message.Trim().Split(' ');
            List<BigInteger> blocks = new List<BigInteger>();
            List<BitSequence> eightBitSequences = new List<BitSequence>();

            foreach (string block in messageBlocks)
            {
                blocks.Add(BigInteger.Parse(block));
                BigInteger resultNumber = BigInteger.ModPow(blocks[blocks.Count - 1], FirstPartClosedKey, SecondPartKey);
                char encryptedSymbol = (char)int.Parse(resultNumber.ToString());

                encryptedMessage.Append(encryptedSymbol);
            }
            return encryptedMessage.ToString();
        }
        public BigInteger Decrypt(BigInteger numberToDecrypt)
        {
            return BigInteger.ModPow(numberToDecrypt, FirstPartClosedKey, SecondPartKey);
        }
        public string EncyptByBlocks(string message, int blockSizeInSymbols)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            List<BitSequence> blocks = new List<BitSequence>();
            while (message.Length % blockSizeInSymbols != 0)
            {
                message += " ";
            }
            for (int i = 0; i < message.Length; i += blockSizeInSymbols)
            {
                blocks.Add(new BitSequence(message.Substring(i, blockSizeInSymbols)));
                BigInteger blockMessage = blocks[blocks.Count - 1].ToBigInteger();
                BigInteger encryptedBlock = this.Encrypt(blockMessage);
                encryptedMessage.Append(encryptedBlock.ToString() + " ");
            }
            return encryptedMessage.ToString();
        }
        public string DecryptByBlocks(string message)
        {
            StringBuilder decryptedMessage = new StringBuilder();
            List<BigInteger> encryptedBigNumbers = new List<BigInteger>();
            string[] encryptedBlocks = message.Trim().Split(' ');
            foreach (string block in encryptedBlocks)
            {
                try
                {
                    encryptedBigNumbers.Add(BigInteger.Parse(block));
                }
                catch
                {
                    throw new Exception("Wrong message format!");
                }
                BigInteger decryptedBigNumber = this.Decrypt(encryptedBigNumbers[encryptedBigNumbers.Count - 1]);
                BitSequence decryptedBitSequence = new BitSequence(decryptedBigNumber);
                decryptedMessage.Append(decryptedBitSequence.ToString());
            }
            return decryptedMessage.ToString();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is RSA))
            {
                return false;
            }
            RSA rsaCypher = (RSA)obj;
            return this.P == rsaCypher.P && this.Q == rsaCypher.Q;
        }
        public override int GetHashCode() =>
            //  8191 и 524287 - числа Мерсена
            this.P.GetHashCode() * 8191 + this.Q.GetHashCode() * 524287;
        public override string ToString() =>
            $"[{FirstPartOpenKey}; {SecondPartKey}] - open key pair, [{FirstPartClosedKey}; {SecondPartKey}] - closed key pair";
    }
}
