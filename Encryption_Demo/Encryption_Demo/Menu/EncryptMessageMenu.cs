using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class EncryptMessageMenu : Menu
    {
        private List<Message> draftMessages;
        private List<Message> selectedMessages = new List<Message>();
        public EncryptMessageMenu(DemoEnvironment environment) : base(environment)
        {
            this.draftMessages = new List<Message>(Environment.CurrentUser.Drafts);
            
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
            Console.WriteLine("Encrypting message selection menu");
            Console.WriteLine("Please select an option below:");
            if (draftMessages.Count > 0)
            {
                for (int i = 0; i < draftMessages.Count; i++)
                {
                    string messageSubject = draftMessages[i].Subject;
                    Console.WriteLine(i + ": " + messageSubject);
                }
            }
            else
            {
                Console.WriteLine("There are no remaining draft messages to select!");
            }


            if (selectedMessages.Count > 0)
            {
                Console.Write("Accept: ");
                foreach (Message message in selectedMessages)
                {
                    Console.Write(message.Subject + ", ");
                }
                Console.Write("\n");
            }

            Console.WriteLine("Back: Go back to previous menu");
        }

        protected override void Cases(string userInput)
        {
            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < draftMessages.Count)
                {
                    selectedMessages.Add(draftMessages[index]);
                    draftMessages.RemoveAt(index);
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
                    case "ACCEPT" when selectedMessages.Count > 0:
                        foreach (Message message in selectedMessages)
                        {
                            KeySelectionMenu selectKey = new KeySelectionMenu(Environment);
                            selectKey.Run();
                            Environment.CurrentUser.EncryptMessage(message);
                        }
                        Console.WriteLine("Message(s) encrypted! Added to encrypted drafts.");

                        return;
                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }
            }
        }
    }
}
