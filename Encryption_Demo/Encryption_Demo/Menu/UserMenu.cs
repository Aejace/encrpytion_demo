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
            Console.WriteLine("B: Share keys");
            Console.WriteLine("C: Write a message");
            Console.WriteLine("D: Encrypt a message");
            Console.WriteLine("E: Send a message");
            Console.WriteLine("F: Intercept a message");
            Console.WriteLine("G: Decrypt a message");
            Console.WriteLine("H: Read messages");
            Console.WriteLine("Back: Go to main menu");
        }

        protected override void Cases(string userInput)
        {
            switch (userInput)
            {
                case "A":
                    GenerateKeyMenu generateKey = new GenerateKeyMenu(Environment);
                    generateKey.Run();
                    break;

                case "B":
                    ShareKeyMenu shareKey = new ShareKeyMenu(Environment);
                    shareKey.Run();
                    break;

                case "C":
                    RecipientSelectionMenu recipientSelection = new RecipientSelectionMenu(Environment);
                    recipientSelection.Run();
                    if (Environment.CurrentUser.PartialMessage.RecipientsList.Count == 0)
                    {
                        break;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Next, add a subject: ");
                    string subject = GetUserInput();
                    Environment.CurrentUser.PartialMessage.Subject = subject;

                    Console.WriteLine("");
                    Console.WriteLine("Next, write the contents of the message: ");
                    string content = GetUserInput();
                    Environment.CurrentUser.PartialMessage.Content = content;

                    Environment.CurrentUser.AddToDrafts();

                    Console.WriteLine("");
                    Console.WriteLine("Message complete. Added to drafts");
                    break;

                case "D" when Environment.CurrentUser.Keys.Count > 0:
                    EncryptMessageMenu encryptMessage = new EncryptMessageMenu(Environment);
                    encryptMessage.Run();
                    break;

                case "E":
                    SendMessageMenu sendMessage = new SendMessageMenu(Environment);
                    sendMessage.Run();
                    break;

                case "F":

                    break;

                case "G":
                    DecryptMessageMenu decryptMessage = new DecryptMessageMenu(Environment);
                    decryptMessage.Run();
                    break;

                case "H":
                    MessageFolderSelectionMenu folderSelect = new MessageFolderSelectionMenu(Environment);
                    folderSelect.Run();
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
