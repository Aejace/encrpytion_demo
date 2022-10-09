using Encryption_Demo;

internal class Demo_Enviroment
{
    private List<User> users = new List<User>();
    private User currentUser;
    private List<Message> messagesHub = new List<Message>();

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome! This program demonstrates some uses of symetric and asymetric encryption.");

        MainMenu();

        Console.WriteLine("");
        Console.WriteLine("Thanks for exploring this demo!");
    }

    public static string GetUserInput()
    {
        var userInput = Console.ReadLine();
        while (userInput == null)
        {
            Console.WriteLine("Please enter a non null value");
            userInput = Console.ReadLine();
        }
        return userInput;
    }

    private static void MainMenu()
    {
        string userInput = "";

        while (userInput != "QUIT")
        {
            Console.WriteLine("");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("A: Add a user to the enviroment");
            Console.WriteLine("B: Log in to a user");
            Console.WriteLine("Quit: Exit the program");

            userInput = GetUserInput();
            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case "A":

                    break;

                case "B":
                    UserSelectionMenu();
                    break;

                case "QUIT":
                    break;

                default:
                    Console.WriteLine("Command not recognized.");
                    break;
            }
        } 
    }

    private static void UserSelectionMenu()
    {
        string userInput = "";

        while (userInput != "QUIT")
        {
            Console.WriteLine("");
            Console.WriteLine("Please select an option below:");
            //if ()

            Console.WriteLine("Back: Go back to main menu");

            userInput = GetUserInput();
            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case "A":

                    break;

                case "B":
                    
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