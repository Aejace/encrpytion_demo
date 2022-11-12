using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class SendMessageMenu : Menu
    {
        private List<Message> draftMessages;
        private List<Message> encryptedMessages;
        private List<Message> selectedMessages = new List<Message>();
        public SendMessageMenu(DemoEnvironment environment) : base(environment)
        {
            this.draftMessages = new List<Message>(Environment.CurrentUser.Drafts);
            this.encryptedMessages = new List<Message>(Environment.CurrentUser.EncryptedDrafts);
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
            int draftIndex = 0;
            Console.WriteLine("");
            Console.WriteLine("Sending message selection menu");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("Drafts - ");
            if (draftMessages.Count > 0)
            {
                for (draftIndex = 0; draftIndex < draftMessages.Count; draftIndex++)
                {
                    string messageSubject = draftMessages[draftIndex].Subject;
                    Console.WriteLine(draftIndex + ": " + messageSubject);
                }
            }
            else
            {
                Console.WriteLine("There are no remaining draft messages to select!");
            }

            Console.WriteLine("Encrypted Drafts - ");
            if (encryptedMessages.Count > 0)
            {
                int extendedIndex = 0;
                for (int encryptedIndex = 0; encryptedIndex < encryptedMessages.Count; encryptedIndex++)
                {
                    string messageSubject = encryptedMessages[encryptedIndex].Subject;
                    extendedIndex = draftIndex + encryptedIndex;
                    Console.WriteLine(extendedIndex + ": " + messageSubject);
                }
            }
            else
            {
                Console.WriteLine("There are no remaining encrypted messages to select!");
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
                int numDraftMessages = draftMessages.Count;
                int numEncryptedMessages = encryptedMessages.Count;
                if (index >= 0 && index < numDraftMessages)
                {
                    selectedMessages.Add(draftMessages[index]);
                    draftMessages.RemoveAt(index);
                }
                else if (index >= numDraftMessages && index < numDraftMessages + numEncryptedMessages)
                {
                    selectedMessages.Add(encryptedMessages[index - numDraftMessages]);
                    encryptedMessages.RemoveAt(index - numDraftMessages);
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
                            Environment.CurrentUser.SendMessage(message);
                            Environment.MessagesHub.SendMessage(message);
                        }
                        Console.WriteLine("Message(s) sent!");

                        return;
                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }
            }
        }
    }
}
