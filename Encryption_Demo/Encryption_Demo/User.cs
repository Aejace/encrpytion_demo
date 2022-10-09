using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo
{
    internal class User
    {
        public string Name { get; }
        public List<IKey> keys = new List<IKey>(); 
        public List<Message> messages = new List<Message>();

        public User(string name)
        {
            Name = name;
        }

        public void createKey()
        {
            BasicKey key = new BasicKey();
            keys.Add(key);
        }
    }
}
