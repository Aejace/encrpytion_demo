using System;
using System.Data;
using System.Numerics;
using System.Text;

namespace Encryption_Demo.Keys
{
    internal class RSA
    {
        public RSAKey PublicKey;
        public RSAKey PrivateKey;
        string name;
        Random random;
        private List<int> primes = new List<int> { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499 };

        public RSA(string name)
        {
            this.name = name;
            random = new Random();
            makeKeys();
        }

        private void makeKeys()
        {
            Random random = new Random();

            // Choose e
            BigInteger publicExponent = 65537;

            BigInteger prime1;
            BigInteger prime2;
            BigInteger primeProduct;
            BigInteger eulerTotient;
            BigInteger privateExponent;
            do
            {
                // Choose two prime numbers
                do
                {
                    prime1 = getRandomPrime();
                }
                while (prime1 % publicExponent == 1);


                do
                {
                    prime2 = getRandomPrime();
                }
                while (prime2 % publicExponent == 1);

                // Compute n = p*q
                primeProduct = prime1 * prime2;

                // Compute phi_n
                eulerTotient = (prime1 - 1) * (prime2 - 1);

                // Calculate d
                privateExponent = ExtendedEulerModuloInverse(publicExponent, eulerTotient);
            }
            while (privateExponent == 0);

            // Make keys
            PublicKey = new RSAKey(name + " (public)", primeProduct, publicExponent);
            PrivateKey = new RSAKey(name + " (private)", primeProduct, privateExponent);
        }

        private bool checkPrecomputedPrimes(BigInteger candidate)
        {
            foreach (int prime in primes)
            {
                if (candidate % prime == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkFermatsLittleTheorem(BigInteger candidate, int numRounds)
        {
            List<BigInteger> witnessList = new List<BigInteger>();

            for (int i = 0; i < numRounds; i++)
            {
                byte[] randomWitness;
                BigInteger witnessInt;
                do
                {
                    randomWitness = new byte[128];
                    random.NextBytes(randomWitness);
                    witnessInt = new BigInteger(randomWitness);
                    if (witnessInt <= 0)
                    {
                        witnessInt = witnessInt * -1;
                    }
                }
                while (witnessInt >= candidate || witnessInt < primes[primes.Count - 1] || witnessList.Contains(witnessInt));

                // Check if witness
                BigInteger remainder = BigInteger.ModPow(witnessInt, candidate - 1, candidate);
                if (remainder != 1)
                {
                    return false;
                }
            }

            return true;
        }

        private BigInteger getRandomPrime()
        {
            while (true)
            {
                // Generate random number
                byte[] randomBytes = new byte[128];
                random.NextBytes(randomBytes);
                randomBytes[0] = (byte)(randomBytes[0] | 128);
                randomBytes[randomBytes.Length - 1] = (byte)(randomBytes[randomBytes.Length - 1] | 1);
                BigInteger primeCandidate = new BigInteger(randomBytes);

                if (primeCandidate <= 0)
                {
                    primeCandidate = primeCandidate * -1;
                }

                if (!checkPrecomputedPrimes(primeCandidate))
                {
                    continue;
                }

                if (!checkFermatsLittleTheorem(primeCandidate, 32))
                {
                    continue;
                }

                return primeCandidate;
            }
        }

        private BigInteger ExtendedEulerModuloInverse(BigInteger publicExponent, BigInteger eulerTotient)
        {
            BigInteger privateExponent, u1, localExponent, v1, localEulerTotient, t1, remainder, quotient;
            int iterator;

            // Initialize
            u1 = 1;
            localExponent = publicExponent;
            v1 = 0;
            localEulerTotient = eulerTotient;

            // Remember odd/even iterations 
            iterator = 1;

            // Loop while v3 != 0 
            while (localEulerTotient != 0)
            {
                // Divide and "Subtract"
                quotient = localExponent / localEulerTotient;
                remainder = localExponent % localEulerTotient;
                t1 = u1 + quotient * v1;

                // Swap
                u1 = v1;
                v1 = t1;
                localExponent = localEulerTotient;
                localEulerTotient = remainder;
                iterator = -iterator;
            }

            // Make sure u3 = gcd(exponent, eulerTotient) == 1 
            if (localExponent != 1)
            {
                return 0; // Error: No inverse exists
            }

            // Ensure a positive result
            if (iterator < 0)
            {
                privateExponent = eulerTotient - u1;
            }
            else
            {
                privateExponent = u1;
            }
            return privateExponent;
        }

        internal class RSAKey : Key
        {
            private BigInteger primeProduct;
            private BigInteger exponent;

            public RSAKey(string name, BigInteger primeProduct, BigInteger exponent)
            {
                Name = name;
                this.primeProduct = primeProduct;
                this.exponent = exponent;
            }

            public override Message Encrypt(Message messageToEncrypt)
            {
                string plainText = messageToEncrypt.Content;
                byte[] plainByte = new byte[plainText.Length];
                for (int i = 0; i < plainText.Length; i++)
                {
                    plainByte[i] = (byte)plainText[i];
                }
                BigInteger plainInt = new BigInteger(plainByte);
                BigInteger cipherInt = BigInteger.ModPow(plainInt, exponent, primeProduct);
                byte[] cipherByte = cipherInt.ToByteArray();
                StringBuilder cipherBuilder = new StringBuilder();
                for (int i = 0; i < cipherByte.Length; i++)
                {
                    cipherBuilder.Append((char)cipherByte[i]);
                }
                string cipherText = cipherBuilder.ToString();
                return new Message(messageToEncrypt.Subject, cipherText, messageToEncrypt.RecipientsList);
            }

            public override Message Decrypt(Message messageToDecrypt)
            {
                string cipherText = messageToDecrypt.Content;
                byte[] cipherByte = new byte[cipherText.Length];
                for (int i = 0; i < cipherText.Length; i++)
                {
                    cipherByte[i] = (byte)cipherText[i];
                }
                BigInteger cipherInt = new BigInteger(cipherByte);
                BigInteger plainInt = BigInteger.ModPow(cipherInt, exponent, primeProduct);
                byte[] plainByte = plainInt.ToByteArray();
                StringBuilder plainBuilder = new StringBuilder();
                for (int i = 0; i < plainByte.Length; i++)
                {
                    plainBuilder.Append((char)plainByte[i]);
                }
                string plainText = plainBuilder.ToString();
                return new Message(messageToDecrypt.Subject, plainText, messageToDecrypt.RecipientsList);
            }
        }
    }
}
