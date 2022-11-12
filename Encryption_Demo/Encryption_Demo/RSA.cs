using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo
{
    internal class RSA
    {
        public RSAKey PublicKey;
        public RSAKey PrivateKey;

        internal class RSAKey : Key
        {
            private int n;
            private int exponent;

            public override Message Decrypt(Message messageToDecrypt)
            {
                return new Message();
            }

            public override Message Encrypt(Message messageToEncrypt)
            {
                return new Message();
            }
        }
    }
}
