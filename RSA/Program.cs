using System;
using System.IO;
using RsaCypher;

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
        static int Main(string[] args)
        {
            string inputMessage, encryptedMessage, decryptedMessage;

            inputMessage = ReadFrom(inputPath);
            int p = 31, q = 109;

            RSA rsaCypher = new RSA(p, q); 
            encryptedMessage = rsaCypher.Encrypt(inputMessage);
            decryptedMessage = rsaCypher.Decrypt(encryptedMessage);
            WriteTo(outputPath, encryptedMessage);

            Console.WriteLine(rsaCypher.ToString());
            Console.WriteLine("Message to encrypt: {0}", inputMessage);
            Console.WriteLine("Encrypted message: {0}", encryptedMessage);
            Console.WriteLine("Decrypted message: {0}\n", decryptedMessage);

            Console.ReadKey();
            return 0;
        }
    }
}
