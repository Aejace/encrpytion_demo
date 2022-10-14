namespace Encryption_Demo.Menu
{
    internal abstract class Menu
    {
        protected DemoEnvironment Environment;
        protected Menu(DemoEnvironment environment)
        {
            this.Environment = environment;
        }

        public void Run()
        {
            string userInput = "";

            while (userInput != "BACK")
            {
                PrintMenu();

                userInput = GetUserInput();
                userInput = userInput.ToUpper();

                Cases(userInput);
            }
        }

        protected string GetUserInput()
        {
            var userInput = Console.ReadLine();
            while (userInput == null)
            {
                Console.WriteLine("Please enter a non null value");
                userInput = Console.ReadLine();
            }

            userInput.TrimStart();
            return userInput;
        }

        protected abstract void PrintMenu();
        protected abstract void Cases(string userInput);


    }
}
