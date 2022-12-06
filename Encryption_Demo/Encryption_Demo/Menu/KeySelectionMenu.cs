using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption_Demo.Keys;

namespace Encryption_Demo.Menu
{
    internal class KeySelectionMenu : Menu
    {
        private List<Key> keys;
        public KeySelectionMenu(DemoEnvironment environment) : base(environment)
        {
            this.keys = Environment.CurrentUser.Keys;
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Key selection menu");
            Console.WriteLine("Please select an option below:");
            if (keys.Count > 0)
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    string keyName = keys[i].Name;
                    Console.WriteLine(i + ": " + keyName);
                }
            }
            else
            {
                Console.WriteLine("There are no keys to select!");
            }

            Console.WriteLine("Back: Go back to previous menu");
        }

        protected override void Cases(string userInput)
        {
            if (userInput == "BACK") return;

            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < keys.Count)
                {
                    Key currentKey = Environment.CurrentUser.Keys[index];
                    Environment.CurrentUser.SetCurrentKey(currentKey); 
                    Console.WriteLine("Current key is now set to: " + Environment.CurrentUser.CurrentKey.Name);
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            else
            {
                Console.WriteLine("Command not recognized.");
            }
        }
    }
}
