using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class ShareKeyMenu : Menu
    {
        private List<string> userNames;
        private List<string> selectedUsers = new List<string>();
        public ShareKeyMenu(DemoEnvironment environment) : base(environment)
        {
            this.userNames = new List<string>(Environment.Users.Keys);
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
            Console.WriteLine("Key recipient selection menu");
            if (userNames.Count > 0)
            {
                Console.WriteLine("Please select an option below:");

                for (int i = 0; i < userNames.Count; i++)
                {
                    string name = userNames[i];
                    Console.WriteLine(i + ": " + name);
                }
            }
            else
            {
                Console.WriteLine("There are no remaining users to select!");
            }

            if (selectedUsers.Count > 0)
            {
                Console.Write("Accept: ");
                foreach (string user in selectedUsers)
                {
                    Console.Write(user + ", ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("Back: Go back to previous menu");
        }

        protected override void Cases(string userInput)
        {
            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < userNames.Count)
                {
                    selectedUsers.Add(userNames[index]);
                    userNames.RemoveAt(index);
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

                    case "ACCEPT" when selectedUsers.Count > 0:
                        KeySelectionMenu selectKey = new KeySelectionMenu(Environment);
                        selectKey.Run();
                        Console.WriteLine("");
                        Console.Write("Keys distributed to: ");
                        foreach (string user in selectedUsers)
                        {
                            Environment.Users[user].AddKey(Environment.CurrentUser.CurrentKey);
                            Console.Write(user + ", ");
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
