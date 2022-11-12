using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo.Menu
{
    internal class DecryptMessageMenu : Menu
    {
        private List<Message> inboxMessages;
        private List<Message> interceptedMessages;
        private List<Message> selectedMessages = new List<Message>();
        public DecryptMessageMenu(DemoEnvironment environment) : base(environment)
        {
            string currentUserName = Environment.CurrentUser.Name;
            List<Message> serverMessages = Environment.MessagesHub.GetUsersMessages(currentUserName);
            Environment.CurrentUser.RefreshInbox(serverMessages);
            this.inboxMessages = new List<Message>(Environment.CurrentUser.Inbox);
            this.interceptedMessages = new List<Message>(Environment.CurrentUser.InterceptedMessages);
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
            int inboxIndex = 0;
            Console.WriteLine("");
            Console.WriteLine("Decrypt message selection menu");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("Inbox - ");
            if (inboxMessages.Count > 0)
            {
                for (inboxIndex = 0; inboxIndex < inboxMessages.Count; inboxIndex++)
                {
                    string messageSubject = inboxMessages[inboxIndex].Subject;
                    Console.WriteLine(inboxIndex + ": " + messageSubject);
                }
            }
            else
            {
                Console.WriteLine("There are no inbox messages to select!");
            }

            Console.WriteLine("Intercepted messages - ");
            if (interceptedMessages.Count > 0)
            {
                int extendedIndex = 0;
                for (int interceptedIndex = 0; interceptedIndex < interceptedMessages.Count; interceptedIndex++)
                {
                    string messageSubject = interceptedMessages[interceptedIndex].Subject;
                    extendedIndex = inboxIndex + interceptedIndex;
                    Console.WriteLine(extendedIndex + ": " + messageSubject);
                }
            }
            else
            {
                Console.WriteLine("There are no intercepted messages to select!");
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
                int inboxMessagesCount = inboxMessages.Count;
                int interceptedMessagesCount = interceptedMessages.Count;
                if (index >= 0 && index < inboxMessagesCount)
                {
                    selectedMessages.Add(inboxMessages[index]);
                    inboxMessages.RemoveAt(index);
                }
                else if (index >= inboxMessagesCount && index < inboxMessagesCount + interceptedMessagesCount)
                {
                    selectedMessages.Add(interceptedMessages[index - inboxMessagesCount]);
                    interceptedMessages.RemoveAt(index - inboxMessagesCount);
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
                        KeySelectionMenu selectKey = new KeySelectionMenu(Environment);
                        selectKey.Run();
                        int numMessagesDecrypted = Environment.CurrentUser.DecryptedInbox.Count;
                        foreach (Message message in selectedMessages)
                        {
                            try
                            {
                                Environment.CurrentUser.DecryptMessage(message);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\"" + message.Subject + "\" could not be decrypted with the selected key");
                            } 
                        }

                        if (Environment.CurrentUser.DecryptedInbox.Count > numMessagesDecrypted)
                        {
                            Console.WriteLine("Message(s) Decrypted!");
                        }
                        return;

                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }
            }
        }
    }
}
