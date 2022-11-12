using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo
{
    internal class SymmetricXORKey : Key
    {
        private BigInteger key;
        public SymmetricXORKey(string name)
        {
            this.Name = name;
            Random random = new Random();
            byte[] ByteKey = new byte[65536];
            random.NextBytes(ByteKey);
            key = new BigInteger(ByteKey);
        }
        public override Message Decrypt(Message messageToDecrypt)
        {
            byte[] cipherByteContent = Encoding.ASCII.GetBytes(messageToDecrypt.Content);
            BigInteger cipherIntContent = new BigInteger(cipherByteContent);
            BigInteger plainInt = cipherIntContent ^ key;
            byte[] plainByte = plainInt.ToByteArray();
            string plainText = System.Text.Encoding.ASCII.GetString(plainByte, 0, plainByte.Length);
            return new Message(messageToDecrypt.Subject, plainText, messageToDecrypt.RecipientsList);
        }

        public override Message Encrypt(Message messageToEncrypt)
        {
            byte[] byteContent = Encoding.ASCII.GetBytes(messageToEncrypt.Content);
            BigInteger intContent = new BigInteger(byteContent);
            BigInteger cipherInt = intContent ^ key;
            byte[] byteCipher = cipherInt.ToByteArray();
            string cipherText = System.Text.Encoding.ASCII.GetString(byteCipher, 0, byteCipher.Length);
            return new Message(messageToEncrypt.Subject, cipherText, messageToEncrypt.RecipientsList);
        }
    }
}
