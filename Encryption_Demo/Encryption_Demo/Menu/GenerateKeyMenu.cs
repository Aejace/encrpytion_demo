using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class GenerateKeyMenu : Menu
    {
        public GenerateKeyMenu(DemoEnvironment environment) : base(environment)
        {
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Key generation menu");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("A: Basic Key");
            Console.WriteLine("B: One Time Pad XOR Key");
            Console.WriteLine("C: RSA Keys");
            Console.WriteLine("Back: Go back to previous menu");
        }

        protected override void Cases(string userInput)
        {
            string name;
            switch (userInput)
            {
                case "A":
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a key name");
                    name = GetName();
                    Console.WriteLine("Please enter a string modifier ");
                    string modifier = GetUserInput();
                    Environment.CurrentUser.CreateBasicKey(name, modifier);
                    break;

                case "B":
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a key name");
                    name = GetName();
                    // Environment.CurrentUser.CreateRSAKey(name, );
                    break;

                case "C":
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a key name");
                    name = GetName();
                    Environment.CurrentUser.CreateXORKey(name);
                    break;

                case "BACK":
                    break;

                default:
                    Console.WriteLine("Command not recognized.");
                    break;
            }
        }

        private string GetName()
        {
            string name = GetUserInput();
            while (true)
            {
                bool isUnique = true;

                foreach (User user in Environment.Users.Values)
                {
                    if (user.Keys.Any(key => name == key.Name))
                    {
                        isUnique = false;
                        Console.WriteLine("That key name is already taken");
                    }
                }

                if (isUnique)
                {
                    return name;
                }

                name = GetUserInput();
            }
        }
    }
}
