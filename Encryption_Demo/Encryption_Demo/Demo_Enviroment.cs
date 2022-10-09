using Encryption_Demo;
using System.Runtime.CompilerServices;

internal class Demo_Enviroment
{
    private List<User> users = new List<User>();
    private User currentUser = new User("Default User");
    private List<Message> messagesHub = new List<Message>();

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome! This program demonstrates some uses of symetric and asymetric encryption.");

        Demo_Enviroment enviroment = new Demo_Enviroment();
        enviroment.MainMenu();

        Console.WriteLine("");
        Console.WriteLine("Thanks for exploring this demo!");
    }

    public string GetUserInput()
    {
        var userInput = Console.ReadLine();
        while (userInput == null)
        {
            Console.WriteLine("Please enter a non null value");
            userInput = Console.ReadLine();
        }
        return userInput;
    }

    private void MainMenu()
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
                    CreateUserMenu();
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

    private void CreateUserMenu()
    {
        string name = "";
        Console.WriteLine("");
        Console.WriteLine("Please enter the name of the user you'd like to add: ");
        name = GetUserInput();
        User newUser = new User(name);
        users.Add(newUser); 
    }


    private void UserSelectionMenu()
    {
        string userInput = "";

        while (userInput != "BACK")
        {
            Console.WriteLine("");

            if (users.Count > 0)
            {
                Console.WriteLine("Please select an option below:");
                for (int i = 0; i < users.Count; i++)
                {
                    string name = users[i].Name;
                    Console.WriteLine(i + ": " + name);
                }

                Console.WriteLine("Back: Go back to main menu");
            }
            else
            {
                Console.WriteLine("There are no users to select, please add a user before login into one.");
                userInput = "BACK";
                break;
            }
            
            userInput = GetUserInput();

            if (int.TryParse(userInput, out int index))
            {
                currentUser = users[index];
                Console.WriteLine("");
                Console.WriteLine("Logged into: " + currentUser.Name);
            }
            else
            {
                userInput = userInput.ToUpper();

                switch (userInput)
                {
                    case "A":

                        break;

                    case "B":

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
}