
namespace InventoryManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Console.WriteLine("Welcome to the Inventory Management System!");

            while (true)
            {
                Console.WriteLine("\nChoose an action by Typing:");
                Console.WriteLine("view to view all products");
                Console.WriteLine("add to add product");
                Console.WriteLine("edit to edit a product");
                Console.WriteLine("delete to delete a product");
                Console.WriteLine("search to search for a product");
                Console.WriteLine("exit to exit the system");


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
                    case "delete":
                        Console.WriteLine("Enter the name of product you want to delete.");
                        string? deleteProductName = Console.ReadLine();
                        inventory.DeleteProduct(deleteProductName!);
                        break;
                    case "search":
                        Console.WriteLine("Enter the name of product you want to search.");
                        string? searchProductName = Console.ReadLine();
                        inventory.SearchForProduct(searchProductName!);
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Please type valid command.");
                        break;
                }
            }






        }
    }
}
