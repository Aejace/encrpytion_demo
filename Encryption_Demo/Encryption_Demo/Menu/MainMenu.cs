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
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("A: Add a user to the environment");
            Console.WriteLine("B: Log in to a user");
            Console.WriteLine(Environment.CurrentUser.Name != Environment.DefaultName
                ? "C: Go to User menu"
                : "C: Go to User menu (unavailable until logged in)");
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
                    UserSelectionMenu userSelection = new UserSelectionMenu(Environment);
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

                case "BACK":
                    break;

                default:
                    Console.WriteLine("Command not recognized.");
                    break;
            }
        }
    }
}
