
using System.Runtime.CompilerServices;

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
                        Console.Write("Enter product name: ");
                        string? name = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Product name cannot be empty. Please enter a valid name:");
                            name = Console.ReadLine();
                        }
                        Console.Write("Enter product price: ");
                        decimal price;
                        while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.WriteLine("Invalid price. Enter a non-negative decimal:");
                        }
                        Console.Write("Enter product quantity: ");
                        int quantity;
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.WriteLine("Invalid quantity. Enter a non-negative integer:");
                        }

                        Product product = new Product(name!, price, quantity);
                        inventory.AddProduct(product);

                        Console.WriteLine("Product added successfully!");
                        break;
                    case "view":
                        List<Product> products = inventory.GetProducts();
                        if (!products.Any())
                        {
                            Console.WriteLine("No products in inventory.");
                        }
                        else
                        {
                            Console.WriteLine("Current products in inventory:");
                            int index = 1;
                            foreach (var p in products)
                            {
                                Console.WriteLine($"{index}. Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
                                index++;
                            }
                        }
                        break;
                    case "edit":
                        Console.WriteLine("Enter the name of product you want to edit:");
                        string? productName = Console.ReadLine();

                        Console.WriteLine("Enter new name or press Enter to keep current:");
                        string? newName = Console.ReadLine();

                        Console.WriteLine("Enter new price or press Enter to keep current:");
                        string? priceInput = Console.ReadLine();
                        decimal? newPrice = null;
                        if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal parsedPrice) && parsedPrice >= 0)
                            newPrice = parsedPrice;

                        Console.WriteLine("Enter new quantity or press Enter to keep current:");
                        string? quantityInput = Console.ReadLine();
                        int? newQuantity = null;
                        if (!string.IsNullOrWhiteSpace(quantityInput) && int.TryParse(quantityInput, out int parsedQuantity) && parsedQuantity >= 0)
                            newQuantity = parsedQuantity;

                        bool updated = inventory.EditProduct(productName!, newName, newPrice, newQuantity);

                        if (updated)
                            Console.WriteLine("Product updated successfully!");
                        else
                            Console.WriteLine("Product not found.");
                        break;
                    case "delete":
                        Console.WriteLine("Enter the name of product you want to delete.");
                        string? deleteProductName = Console.ReadLine();
                        bool deleted = inventory.DeleteProduct(deleteProductName!);
                        if (deleted)
                            Console.WriteLine("Product deleted successfully!");
                        else
                            Console.WriteLine("Product not found.");
                        break;
                    case "search":
                        Console.WriteLine("Enter the name of product you want to search.");
                        string? searchProductName = Console.ReadLine();
                        Product? foundProduct = inventory.searchProduct(searchProductName!);
                        if (foundProduct != null)
                        {
                            Console.WriteLine($"Product found: {foundProduct.Name}, Price: {foundProduct.Price}, Quantity: {foundProduct.Quantity}");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
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
