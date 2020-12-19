using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using RsaCypher;
using RsaCypher.BitSequenceLib;

namespace RSA_ConsoleExample
{
    class Program
    {
        private static readonly string inputPath = "message.txt";
        private static readonly string outputPath = "encryptedMessage.txt";

        static string ReadFrom(string path) => new StreamReader(path).ReadToEnd();
        static void WriteTo(string path, string message)
        {
            using (StreamWriter input = new StreamWriter(path))
            {
                input.WriteLine(message);
            }
        }

        static string EncyptByBlocks(RSA rsaCypher, string message, int blockSizeInSymbols)
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
                BigInteger encryptedBlock = rsaCypher.Encrypt(blockMessage);
                encryptedMessage.Append(encryptedBlock.ToString() + " ");
            }
            return encryptedMessage.ToString();
        }
        static string DecryptByBlocks(RSA rsaCypher, string message)
        {
            StringBuilder decryptedMessage = new StringBuilder();
            List<BigInteger> encryptedBigNumbers = new List<BigInteger>();
            string[] encryptedBlocks = message.Trim().Split(' ');
            foreach (string block in encryptedBlocks)
            {
                encryptedBigNumbers.Add(BigInteger.Parse(block));
                BigInteger decryptedBigNumber = rsaCypher.Decrypt(encryptedBigNumbers[encryptedBigNumbers.Count - 1]);
                BitSequence decryptedBitSequence = new BitSequence(decryptedBigNumber);
                decryptedMessage.Append(decryptedBitSequence.ToString());
            }
            return decryptedMessage.ToString();
        }

        static int Main(string[] args)
        {
            string message = "world at war, my boy. Get prepared for real rock'n'roll";
            string encryptedMessage = string.Empty;
            string decryptedMessage = string.Empty;
            RSA rsaCypher = new RSA(1231231231312261, 1231231231312469);

            Console.WriteLine("ENCRYPTING...");
            encryptedMessage = EncyptByBlocks(rsaCypher, message, 8);
            Console.WriteLine(encryptedMessage);

            Console.WriteLine("DECRYPTING...");
            decryptedMessage = DecryptByBlocks(rsaCypher, encryptedMessage);
            Console.WriteLine(decryptedMessage);

            Console.ReadKey();
            return 0;
        }
    }
}
