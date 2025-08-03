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
                Console.WriteLine("Type view to view all products");
                Console.WriteLine("Type add to add product");
                Console.WriteLine("Type edit to edit a product");
                Console.WriteLine("Type exit to exit the system");


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
                    case "edit":
                        Console.WriteLine("Enter the name of product you want to edit.");
                        string? productName = Console.ReadLine();
                        inventory.EditProduct(productName!);
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
