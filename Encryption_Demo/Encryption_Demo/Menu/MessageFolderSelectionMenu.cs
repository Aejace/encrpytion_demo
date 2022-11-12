using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class MessageFolderSelectionMenu : Menu
    {
        public MessageFolderSelectionMenu(DemoEnvironment environment) : base(environment)
        {
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Message folder selection menu");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("A: Inbox");
            Console.WriteLine("B: Intercepted Messages");
            Console.WriteLine("C: Decrypted Messages");
            Console.WriteLine("D: Drafts");
            Console.WriteLine("E: Encrypted Drafts");
            Console.WriteLine("F: Sent");
            Console.WriteLine("Back: Go back to previous menu");
        }

        protected override void Cases(string userInput)
        {
            switch (userInput)
            {
                case "A":
                    Console.WriteLine("");
                    Console.WriteLine("Inbox:");
                    string currentUserName = Environment.CurrentUser.Name;
                    List<Message> inboxMessages = Environment.MessagesHub.GetUsersMessages(currentUserName);
                    Environment.CurrentUser.RefreshInbox(inboxMessages);
                    foreach (Message message in Environment.CurrentUser.Inbox)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(message.PrintMessage());
                    }
                    break;

                case "B":
                    
                    break;

                case "C":
                    
                    break;

                case "D":

                    break;

                case "E":

                    break;

                case "F":

                    break;

                case "BACK":
                    break;

                default:
                    Console.WriteLine("Command not recognized.");
                    break;
            }
        }
    }
}
