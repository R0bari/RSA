using System.Numerics;
using System.Text;

namespace RsaCypher
{
    public class RSA : ICypher
    {
        public int P { get; set; }
        public int Q { get; set; }

        public int M { get; private set; }
        public int N { get; set; }
        public int D { get; set; }
        public int E { get; set; }


        public RSA() { }
        //  [e; n] - open key pair, [d; n] - closed key pair
        public RSA(int p, int q)
        {
            Init(p, q);
        }
        private void Init(int p, int q)
        {
            P = p;
            Q = q;

            M = (P - 1) * (Q - 1);
            N = P * Q;
            D = CalculateCoprime(M);
            E = CalculateE(D, M);
        }
        private int CalculateCoprime(int number)
        {
            int coprimeNumber = 1;
            do
            {
                ++coprimeNumber;
            } while (!(IsPrimeNumber(coprimeNumber) && number % coprimeNumber != 0));

            return coprimeNumber;

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
        }
        private int CalculateE(int d, int m)
        {
            int e = 0;
            while (d * ++e % m != 1) ;
            return e;
        }
        public string Encrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            char encryptedSymbol;
            foreach (char symbol in message)
            {
                BigInteger pow = BigInteger.Pow(symbol, E);
                BigInteger.DivRem(pow, N, out BigInteger calculatinResult);
                encryptedSymbol = (char)calculatinResult;
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
                BigInteger pow = BigInteger.Pow(symbol, D);
                BigInteger.DivRem(pow, N, out BigInteger calculatinResult);
                encryptedSymbol = (char)calculatinResult;
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
            $"[{E}; {N}] - open key pair, [{D}; {N}] - closed key pair";
    }
}
