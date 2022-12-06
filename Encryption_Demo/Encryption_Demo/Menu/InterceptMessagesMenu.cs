using Encryption_Demo.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class InterceptMessagesMenu : Menu
    {
        private List<Message> messages;
        private List<Message> selectedMessages = new List<Message>();
        public InterceptMessagesMenu(DemoEnvironment environment) : base(environment)

        {
            this.messages = new List<Message>(Environment.MessagesHub.HackTheHub());
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
            Console.WriteLine("Message selection menu");
            if (messages.Count > 0)
            {
                Console.WriteLine("Please select an option below:");

                for (int i = 0; i < messages.Count; i++)
                {
                    Console.WriteLine(i + ": ");
                    messages[i].PrintMessage();
                }
            }
            else
            {
                Console.WriteLine("There are no remaining messages to select!");
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
                if (index >= 0 && index < messages.Count)
                {
                    selectedMessages.Add(messages[index]);
                    messages.RemoveAt(index);
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
                        Console.Write("Messages added to Intercepted inbox: ");
                        foreach (Message message in selectedMessages)
                        {
                            Environment.CurrentUser.InterceptMessage(message);
                            Console.Write(message.Subject + ", ");
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
