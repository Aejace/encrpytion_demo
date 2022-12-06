using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Keys
{
    internal class SymmetricXORKey : Key
    {
        private byte[] key;
        public SymmetricXORKey(string name)
        {
            Name = name;
            Random random = new Random();
            key = new byte[1000];
            random.NextBytes(key);
        }

        public override Message Encrypt(Message messageToEncrypt)
        {
            string plainContent = messageToEncrypt.Content;

            if (plainContent.Length > key.Length)
            {
                throw new Exception("Message length exceeds XOR key length");
            }
            else
            {
                StringBuilder cipherBuilder = new StringBuilder();
                for (int i = 0; i < plainContent.Length; i++)
                {
                    cipherBuilder.Append((char)(plainContent[i] ^ key[i % key.Length]));
                }

                string cipherText = cipherBuilder.ToString();
                return new Message(messageToEncrypt.Subject, cipherText, messageToEncrypt.RecipientsList);
            }
        }

        public override Message Decrypt(Message messageToDecrypt)
        {
            string cipherContent = messageToDecrypt.Content;

            if (cipherContent.Length > key.Length)
            {
                throw new Exception("Message length exceeds XOR key length");
            }
            else
            {
                StringBuilder plainTextBuilder = new StringBuilder();
                for (int i = 0; i < cipherContent.Length; i++)
                {
                    plainTextBuilder.Append((char)(cipherContent[i] ^ key[i % key.Length]));
                }

                string plainText = plainTextBuilder.ToString();
                return new Message(messageToDecrypt.Subject, plainText, messageToDecrypt.RecipientsList);
            }
        }
    }
}
