using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Encryption_Demo.Menu
{
    internal class CreateUserMenu : Menu
    {
        public CreateUserMenu(DemoEnvironment environment) : base(environment)
        {
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the name of the user you'd like to add, or type 'back' to cancel: ");
        }

        protected override void Cases(string userInput)
        {
            if (userInput == "BACK")
            {
                return;
            }

            string name = userInput;

            if (name == Environment.DefaultName)
            {
                Console.WriteLine("Invalid user name");
                return;
            }

            User newUser = new User(name);

            if (Environment.Users.TryAdd(name, newUser))
            {
                Console.WriteLine(name + " added");
            }
            else
            {
                Console.WriteLine("Invalid user name");
            }
        }
    }
}
