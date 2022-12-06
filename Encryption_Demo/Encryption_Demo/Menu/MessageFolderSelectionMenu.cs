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
                    Console.WriteLine("");
                    Console.WriteLine("Intercepted Messages:");
                    foreach (Message message in Environment.CurrentUser.InterceptedMessages)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(message.PrintMessage());
                    }
                    break;

                case "C":
                    Console.WriteLine("");
                    Console.WriteLine("Decrypted Messages:");
                    foreach (Message message in Environment.CurrentUser.DecryptedInbox)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(message.PrintMessage());
                    }
                    break;

                case "D":
                    Console.WriteLine("");
                    Console.WriteLine("Drafts:");
                    foreach (Message message in Environment.CurrentUser.Drafts)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(message.PrintMessage());
                    }
                    break;

                case "E":
                    Console.WriteLine("");
                    Console.WriteLine("Encrypted Drafts:");
                    foreach (Message message in Environment.CurrentUser.EncryptedDrafts)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(message.PrintMessage());
                    }
                    break;

                case "F":
                    Console.WriteLine("");
                    Console.WriteLine("Sent:");
                    foreach (Message message in Environment.CurrentUser.Sent)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(message.PrintMessage());
                    }
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
