namespace RsaCypher
{
    interface ICypher
    {
        string Encrypt(string message);
        string Decrypt(string message);
    }
}
