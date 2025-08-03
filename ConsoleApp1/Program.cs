// See https://aka.ms/new-console-template for more information
namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Console.WriteLine("Welcome to the Inventory Management System!");

            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("Type exit to exit the system");
                Console.WriteLine("Type add to add product");

                Console.Write("Your command: ");
                string input = Console.ReadLine()!.ToLower();
                switch (input)
                {
                    case "add":
                        inventory.AddProduct();
                        break;
                    case "view":
                        inventory.GetProducts();
                    
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Please type valid command.");
                        break;
                }
            }






        }
    }
}
