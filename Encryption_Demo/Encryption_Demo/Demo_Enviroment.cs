using Encryption_Demo;
using System.Runtime.CompilerServices;

internal class Demo_Enviroment
{
    private List<User> users = new List<User>();
    private static string defaultName = "DEFAULT USER";
    private User currentUser = new User(defaultName);

    private List<Message> messagesHub = new List<Message>();

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome! This program demonstrates some uses of symmetric and asymmetric encryption.");

        Demo_Enviroment environment = new Demo_Enviroment();
        environment.MainMenu();

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
            Console.WriteLine("A: Add a user to the environment");
            Console.WriteLine("B: Log in to a user");
            Console.WriteLine(currentUser.Name != defaultName
                ? "C: Go to User menu"
                : "C: Go to User menu (unavailable until logged in)");
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

                case "C":
                    if (currentUser.Name != defaultName)
                    {
                        UserMenu();
                    }
                    else
                    {
                        Console.WriteLine("Please log in to continue");
                    }
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

        while (name != "BACK")
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the name of the user you'd like to add, or type 'back' to cancel: ");
            name = GetUserInput();
            name = name.ToUpper();
            if (name == defaultName || !IsUnique(name))
            {
                Console.WriteLine("Invalid user name");
            }
            else if (name == "BACK")
            {
                continue;
            }
            else
            {
                User newUser = new User(name);
                users.Add(newUser);
                Console.WriteLine(name + " added");
            }
        }
    }

    private bool IsUnique(string name)
    {
        return users.All(t => t.Name != name);
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
                continue;
            }
            
            userInput = GetUserInput();

            if (int.TryParse(userInput, out int index))
            {
                if (index >= 0 && index < users.Count)
                {
                    currentUser = users[index];
                    Console.WriteLine("");
                    Console.WriteLine("Logged into: " + currentUser.Name);
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
            else
            {
                userInput = userInput.ToUpper();

                if (userInput == "BACK") continue;
                Console.WriteLine("Command not recognized.");
            }
        }
    }

    private void UserMenu()
    {
        string userInput = "";

        while (userInput != "BACK")
        {
            Console.WriteLine("");
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("A: Generate keys");
            Console.WriteLine("B: Write a message");
            Console.WriteLine("C: Encrypt a message");
            Console.WriteLine("D: Decrypt a message");
            Console.WriteLine("Back: Go to main menu");

            userInput = GetUserInput();
            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case "A":
                    
                    break;

                case "B":
                    
                    break;

                case "C":
                    
                    break;

                case "D":

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