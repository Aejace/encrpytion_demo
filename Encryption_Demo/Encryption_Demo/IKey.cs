namespace Encryption_Demo
{
    internal interface IKey
    {
        Message Decrypt(Message messageToDecrypt);
        Message Encrypt(Message messageToEncrypt);
    }
}