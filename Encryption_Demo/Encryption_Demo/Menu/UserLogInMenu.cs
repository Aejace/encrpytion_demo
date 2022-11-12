using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class UserLogInMenu : Menu
    {
        private readonly List<string> userNames;

        public UserLogInMenu(DemoEnvironment environment) : base(environment)
        {
            this.userNames = new List<string>(Environment.Users.Keys);
        }


        protected override void PrintMenu()
        {
            Console.WriteLine("");

            if (userNames.Count <= 0)
            {
                Console.WriteLine("There are no users to select, please add a user before login into one.");
            }

            Console.WriteLine("Please select an option below:");

            for (int i = 0; i < userNames.Count; i++)
            {
                string name = userNames[i];
                Console.WriteLine(i + ": " + name);
            }

            Console.WriteLine("Back: Go back to main menu");
        }

        protected override void Cases(string userInput)
        {
            if (userInput == "BACK") return;

            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < userNames.Count)
                {
                    Environment.CurrentUser = Environment.Users[userNames[index]];
                    Console.WriteLine("Logged into: " + Environment.CurrentUser.Name);
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
