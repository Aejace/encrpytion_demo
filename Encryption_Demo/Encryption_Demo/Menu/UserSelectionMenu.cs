﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class UserSelectionMenu : Menu
    {
        private List<string> _userNames;
        private string _userInput;
        private List<string> selectedUsers;
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

            if (_userNames.Count > 0)
            {
                Console.WriteLine("Please select an option below:");

                for (int i = 0; i < _userNames.Count; i++)
                {
                    string name = _userNames[i];
                    Console.WriteLine(i + ": " + name);
                }
            }
            else
            {
                Console.WriteLine("There are no users to select!");
            }

            Console.WriteLine("Accept: Accept User List");
            Console.WriteLine("Back: Go back to previous menu");
        }

        protected override void Cases(string userInput)
        {
            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < _userNames.Count)
                {
                    // TODO: Change this so it builds a list of _selectedUsers
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
                if (userInput == "ACCEPT")
                {
                    // TODO: Change this so it hits up the partial message inside current user
                }
                Console.WriteLine("Command not recognized.");
            }
        }
    }
}

