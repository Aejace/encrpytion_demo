namespace Encryption_Demo
{
    internal class BasicKey : IKey
    {
        private readonly string _cipherAddition = " (This is a modification to the message to show it is 'encrypted')";

        public BasicKey()
        {

        }

        public BasicKey(string cipherAddition)
        {
            this._cipherAddition = cipherAddition;
        }

        public Message Encrypt(Message messageToEncrypt)
        {
            string encryptedContent = messageToEncrypt.Content + _cipherAddition;
            Message encryptedMessage = new Message(messageToEncrypt.Subject, encryptedContent, messageToEncrypt.RecipientsList);
            return encryptedMessage;
        }

        public Message Decrypt(Message messageToDecrypt)
        {
            string decryptedContent =  messageToDecrypt.Content.Substring(0, messageToDecrypt.Content.Length - _cipherAddition.Length);
            Message decryptedMessage = new Message(messageToDecrypt.Subject, decryptedContent, messageToDecrypt.RecipientsList);
            return decryptedMessage;
        }
    }
}
