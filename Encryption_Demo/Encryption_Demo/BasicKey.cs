namespace Encryption_Demo
{
    internal class BasicKey : IKey
    {
        private readonly string _cipherAddition = " (This is a modification to the message to show it is 'encrpyted')";

        public BasicKey()
        {

        }

        public BasicKey(string cipherAddition)
        {
            this._cipherAddition = cipherAddition;
        }

        public void Encrypt(Message messageToEncrypt)
        {
            messageToEncrypt.Content += _cipherAddition;
        }

        public void Decrypt(Message messageToDecrypt)
        {
            messageToDecrypt.Content = messageToDecrypt.Content.Substring(0, messageToDecrypt.Content.Length - _cipherAddition.Length);
        }
    }
}
