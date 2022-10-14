using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class UserSelectionMenu : Menu
    {
        private readonly List<string> _userNames;
        private string _userInput;

        public UserSelectionMenu(DemoEnvironment environment) : base(environment)
        {
            this._userNames = new List<string>(Environment.Users.Keys);
            this._userInput = "";
        }

        public new void Run()
        {
            while (_userInput != "BACK")
            {
                PrintMenu();

                _userInput = GetUserInput();

                Cases(_userInput);
            }
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");

            if (Environment.Users.Count <= 0)
            {
                Console.WriteLine("There are no users to select, please add a user before login into one.");
                _userInput = "BACK";
                return;
            }

            Console.WriteLine("Please select an option below:");

            for (int i = 0; i < _userNames.Count; i++)
            {
                string name = _userNames[i];
                Console.WriteLine(i + ": " + name);
            }

            Console.WriteLine("Back: Go back to main menu");
        }

        protected override void Cases(string userInput)
        {
            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < Environment.Users.Count)
                {
                    Environment.CurrentUser = Environment.Users[_userNames[index]];
                    Console.WriteLine("");
                    Console.WriteLine("Logged into: " + Environment.CurrentUser.Name);
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            else
            {
                userInput = userInput.ToUpper();

                if (userInput == "BACK") return;
                Console.WriteLine("Command not recognized.");
            }
        }
    }
}
