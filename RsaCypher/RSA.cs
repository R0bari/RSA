using System;
using System.Text;

namespace RsaCypher
{
    public class RSA : ICypher
    {
        /// <summary>
        /// Neccessary constant required to init keys.
        /// To init open key pair and closed key pair required  
        /// initialising "P" and "Q" and then calling method "Init"
        /// </summary>
        public int P { get; set; }
        /// <summary>
        /// Neccessary constant required to init keys.
        /// To init open key pair and closed key pair required  
        /// initialising "P" and "Q" and then calling method "Init"
        /// </summary>
        public int Q { get; set; }
        public int M { get; set; }
        /// <summary>
        /// "e" in open key pair - [e; n] 
        /// </summary>
        public int FirstPartOfOpenKey { get; set; }
        /// <summary>
        /// "d" in closed key pair - [d; n]
        /// </summary>
        public int FirstPartOfClosedKey { get; set; }
        /// <summary>
        /// "n" in open key pair - [e; n] and in closed key pair [d; n]
        /// </summary>
        public int SecondPartOfKey { get; set; }

        //  FirstPartOfClosedKey - e, FirstPartOfOpenKey - d
        //  SecondPartOfKey - n
        //  [e; n] - open key pair, [d; n] - closed key pair
        public RSA() { }
        public RSA(int p, int q)
        {
            Init(p, q);
        }
        public void Init(int p, int q)
        {
            P = p;
            Q = q;
            Init();
        }
        public void Init()
        {
            M = (P - 1) * (Q - 1);
            SecondPartOfKey = P * Q;
            FirstPartOfClosedKey = CalculateCoprime(M);
            FirstPartOfOpenKey = CalculateE(FirstPartOfClosedKey, M);
        }
        private int CalculateCoprime(int number)
        {
            int[] cases = new int[10];
            int coprimeNumber = 1, casesCount = 5, currentCaseNumber = 0;

            while (currentCaseNumber < casesCount)
            {
                if (IsPrimeNumber(coprimeNumber) && !HaveCommonFactors(number, coprimeNumber))
                {
                    cases[currentCaseNumber] = coprimeNumber;
                    ++currentCaseNumber;
                }
                ++coprimeNumber;
            }
            int randomIndex = new Random().Next(0, casesCount);
            return cases[0];

            bool IsPrimeNumber(int n)
            {
                var result = true;

                if (n > 1)
                {
                    for (var i = 2u; i < n; i++)
                    {
                        if (n % i == 0)
                        {
                            result = false;
                            break;
                        }
                    }
                }
                else
                {
                    result = false;
                }

                return result;
            }
            bool HaveCommonFactors(int first, int second) => first % second == 0 || second % first == 0;
        }
        private int CalculateE(int d, int m)
        {
            int[] cases = new int[10];
            int e = 1, casesCount = 5, currentCaseNumber = 0;

            while (currentCaseNumber < casesCount)
            {
                if (d * e % m == 1)
                {
                    cases[currentCaseNumber++] = e;
                }
                e++;
            }
            int randomIndex = new Random().Next(0, casesCount);
            return cases[0];
        }
        public string Encrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            char encryptedSymbol;
            foreach (char symbol in message)
            {
                BigInt poweredNumber = BigInt.Pow(new BigInt(symbol), FirstPartOfOpenKey);
                BigInt resultNumber = poweredNumber % SecondPartOfKey;
                encryptedSymbol = (char)int.Parse(resultNumber.ToString());

                encryptedMessage.Append(encryptedSymbol);
            }
            return encryptedMessage.ToString();
        }
        public string Decrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            char encryptedSymbol;
            foreach (char symbol in message)
            {
                BigInt poweredNumber = BigInt.Pow(new BigInt(symbol), FirstPartOfClosedKey);
                BigInt resultNumber = poweredNumber % SecondPartOfKey;
                encryptedSymbol = (char)int.Parse(resultNumber.ToString());

                encryptedMessage.Append(encryptedSymbol);
            }
            return encryptedMessage.ToString();
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
            $"[{FirstPartOfOpenKey}; {SecondPartOfKey}] - open key pair, [{FirstPartOfClosedKey}; {SecondPartOfKey}] - closed key pair";
    }
}
