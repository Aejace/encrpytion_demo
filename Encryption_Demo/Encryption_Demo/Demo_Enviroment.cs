using Encryption_Demo.Menu;

namespace Encryption_Demo;

internal class DemoEnvironment
{
    public Dictionary<string, User> Users = new Dictionary<string, User>();

    public string DefaultName = "DEFAULT USER";
    public User CurrentUser;

    public MessageHub MessagesHub = new MessageHub();
    public PublicKeyHub PublicKeyHub = new PublicKeyHub();

    private static void Main(string[] args)
    {
        DemoEnvironment environment = new DemoEnvironment();
        environment.CurrentUser = new User(environment.DefaultName);

        Console.WriteLine("Welcome! This program demonstrates some uses of symmetric and asymmetric encryption.");
        MainMenu main = new MainMenu(environment);
        main.Run();

        Console.WriteLine("");
        Console.WriteLine("Thanks for exploring this demo!");
    }
}