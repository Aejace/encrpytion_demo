namespace Encryption_Demo
{
    internal class BasicKey : Key
    {
        private readonly string cipherAddition = " (This is a modification to the message to show it is 'encrypted')";
        

        public BasicKey()
        {
            this.Name = "Default name";
        }

        public BasicKey(string name, string cipherAddition)
        {
            this.cipherAddition = cipherAddition;
            this.Name = name;
        }

        public override Message Encrypt(Message messageToEncrypt)
        {
            string encryptedContent = messageToEncrypt.Content + cipherAddition;
            Message encryptedMessage = new Message(messageToEncrypt.Subject, encryptedContent, messageToEncrypt.RecipientsList);
            return encryptedMessage;
        }

        public override Message Decrypt(Message messageToDecrypt)
        {
            string decryptedContent =  messageToDecrypt.Content.Substring(0, messageToDecrypt.Content.Length - cipherAddition.Length);
            Message decryptedMessage = new Message(messageToDecrypt.Subject, decryptedContent, messageToDecrypt.RecipientsList);
            return decryptedMessage;
        }
    }
}
