using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class UserMenu : Menu
    {
        public UserMenu(DemoEnvironment environment) : base(environment)
        {
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("A: Generate keys");
            Console.WriteLine("B: Write a message");
            Console.WriteLine("C: Encrypt a message");
            Console.WriteLine("D: Decrypt a message");
            Console.WriteLine("Back: Go to main menu");
        }

        protected override void Cases(string userInput)
        {
            switch (userInput)
            {
                case "A":

                    break;

                case "B":

                    break;

                case "C":

                    break;

                case "D":

                    break;

                case "QUIT":
                    break;

                default:
                    Console.WriteLine("Command not recognized.");
                    break;
            }
        }
    }
}
