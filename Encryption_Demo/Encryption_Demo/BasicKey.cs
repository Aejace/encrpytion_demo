using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo
{
    internal class BasicKey : IKey
    {
        private string cipherAddition = " (This is a modification to the message to show it is 'encrpyted')";

        public BasicKey()
        {

        }

        public BasicKey(string cipherAddition)
        {
            this.cipherAddition = cipherAddition;
        }

        public void Encrpyt(Message messageToEncrypt)
        {
            messageToEncrypt.message += cipherAddition;
        }

        public void Decrypt(Message messageToDecrypt)
        {
            messageToDecrypt.message = messageToDecrypt.message.Substring(0, messageToDecrypt.message.Length - cipherAddition.Length);
        }
    }
}
