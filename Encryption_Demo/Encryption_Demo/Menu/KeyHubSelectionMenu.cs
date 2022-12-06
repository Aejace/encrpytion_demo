using Encryption_Demo.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class KeyHubSelectionMenu : Menu
    {
        private List<Key> keys;
        private List<Key> selectedKeys = new List<Key>();
        public KeyHubSelectionMenu(DemoEnvironment environment) : base(environment)
        {
            this.keys = new List<Key>(Environment.PublicKeyHub.GetKeys());
        }

        public new void Run()
        {
            string userInput = "";

            while (userInput != "BACK" && userInput != "ACCEPT")
            {
                PrintMenu();

                userInput = GetUserInput();
                userInput = userInput.ToUpper();

                Cases(userInput);
            }
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Key selection menu");
            if (keys.Count > 0)
            {
                Console.WriteLine("Please select an option below:");

                for (int i = 0; i < keys.Count; i++)
                {
                    string name = keys[i].Name;
                    Console.WriteLine(i + ": " + name);
                }
            }
            else
            {
                Console.WriteLine("There are no remaining keys to select!");
            }

            if (selectedKeys.Count > 0)
            {
                Console.Write("Accept: ");
                foreach (Key key in selectedKeys)
                {
                    Console.Write(key.Name + ", ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("Back: Go back to previous menu");
        }

        protected override void Cases(string userInput)
        {
            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < keys.Count)
                {
                    selectedKeys.Add(keys[index]);
                    keys.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            else
            {
                switch (userInput)
                {
                    case "BACK":
                        return;

                    case "ACCEPT" when selectedKeys.Count > 0:
                        Console.Write("Keys added: ");
                        foreach (Key key in selectedKeys)
                        {
                            Environment.CurrentUser.AddKey(key);
                            Console.Write(key.Name + ", ");
                        }
                        Console.Write("\n");
                        break;

                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }
            }
        }
    }
}
