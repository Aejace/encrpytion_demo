using Encryption_Demo.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo
{
    
    internal class PublicKeyHub
    {
        private List<Key> Keys = new List<Key>();

        public void addKey(Key key)
        {
            Keys.Add(key);
        }

        public List<Key> GetKeys()
        {
            return Keys;
        }
    }
}
