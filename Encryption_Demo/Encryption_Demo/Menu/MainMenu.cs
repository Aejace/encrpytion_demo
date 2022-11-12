namespace Encryption_Demo.Menu
{
    internal class MainMenu : Menu
    {
        public MainMenu(DemoEnvironment environment) : base(environment)
        {
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Main menu");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("A: Add a user to the environment");
            Console.WriteLine("B: Log in to a user");
            Console.WriteLine(Environment.CurrentUser.Name != Environment.DefaultName
                ? "C: Go to User menu (" + Environment.CurrentUser.Name + ")"
                : "C: Go to User menu (unavailable until logged in)");
            if (Environment.Users.Count == 0)
            {
                Console.WriteLine("D: Demo");
            }
            Console.WriteLine("Back: Exit the program");
        }

        protected override void Cases(string userInput)
        {
            switch (userInput)
            {
                case "A":
                    CreateUserMenu createUser = new CreateUserMenu(Environment);
                    createUser.Run();
                    break;

                case "B":
                    UserLogInMenu userSelection = new UserLogInMenu(Environment);
                    userSelection.Run();
                    break;

                case "C":
                    if (Environment.CurrentUser.Name != Environment.DefaultName)
                    {
                        UserMenu userMenu = new UserMenu(Environment);
                        userMenu.Run();
                    }
                    else
                    {
                        Console.WriteLine("Please log in to continue");
                    }
                    break;

                case "D" when Environment.Users.Count == 0:
                    User p1 = new User("P1");
                    Environment.Users.Add("P1", p1);
                    User p2 = new User("P2");
                    Environment.Users.Add("P2", p2);
                    User p3 = new User("P3");
                    Environment.Users.Add("P3", p3);
                    Environment.CurrentUser = Environment.Users["P1"];

                    List<string> userNames = new List<string>() {"P1", "P2", "P3"};
                    Message message = new Message("Hello", "Testing", userNames);
                    Environment.CurrentUser.PartialMessage = message;
                    Environment.CurrentUser.AddToDrafts();
                    Environment.CurrentUser.EncryptMessage(message);
                    Message encryptedMessage = Environment.CurrentUser.EncryptedDrafts[0];
                    Environment.CurrentUser.SendMessage(message);
                    Environment.MessagesHub.SendMessage(message);
                    Environment.CurrentUser.SendMessage(encryptedMessage);
                    Environment.MessagesHub.SendMessage(encryptedMessage);
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
