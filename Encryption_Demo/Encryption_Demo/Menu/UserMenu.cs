using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            Console.WriteLine("C: Get public key from key-hub");
            Console.WriteLine("D: Write a message");
            Console.WriteLine("E: Encrypt a message");
            Console.WriteLine("F: Send a message");
            Console.WriteLine("G: Intercept a message");
            Console.WriteLine("H: Decrypt a message");
            Console.WriteLine("I: Read messages");
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

                case "B" when Environment.CurrentUser.Keys.Count > 0:
                    ShareKeyMenu shareKey = new ShareKeyMenu(Environment);
                    shareKey.Run();
                    break;

                case "C":
                    KeyHubSelectionMenu keyHubSelection = new KeyHubSelectionMenu(Environment);
                    keyHubSelection.Run();
                    break;

                case "D":
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

                case "E" when Environment.CurrentUser.Keys.Count > 0 && Environment.CurrentUser.Drafts.Count > 0:
                    EncryptMessageMenu encryptMessage = new EncryptMessageMenu(Environment);
                    encryptMessage.Run();
                    break;

                case "F" when Environment.CurrentUser.Drafts.Count > 0:
                    SendMessageMenu sendMessage = new SendMessageMenu(Environment);
                    sendMessage.Run();
                    break;

                case "G":
                    InterceptMessagesMenu interceptMessage = new InterceptMessagesMenu(Environment);
                    interceptMessage.Run();
                    break;

                case "H" when Environment.CurrentUser.Keys.Count > 0:
                    DecryptMessageMenu decryptMessage = new DecryptMessageMenu(Environment);
                    decryptMessage.Run();
                    break;

                case "I":
                    MessageFolderSelectionMenu folderSelect = new MessageFolderSelectionMenu(Environment);
                    folderSelect.Run();
                    break;

                case "QUIT":
                    break;

                default:
                    if (Environment.CurrentUser.Keys.Count > 0 && (userInput == "B" || userInput == "E" || userInput == "H"))
                    {
                        Console.WriteLine("You have no keys");
                    }
                    else
                    {
                        Console.WriteLine("Command not recognized.");
                    }
                    break;
            }
        }
    }
}
