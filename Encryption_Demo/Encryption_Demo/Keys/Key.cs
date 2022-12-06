namespace Encryption_Demo.Keys
{
    internal abstract class Key
    {
        public abstract Message Decrypt(Message messageToDecrypt);
        public abstract Message Encrypt(Message messageToEncrypt);
        public string Name { get; set; }
    }
}