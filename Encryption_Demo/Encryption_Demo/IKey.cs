namespace Encryption_Demo
{
    internal interface IKey
    {
        void Decrypt(Message messageToDecrypt);
        void Encrypt(Message messageToEncrypt);
    }
}