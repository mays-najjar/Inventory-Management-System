using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Inventory
    {
        private List<Product> products;
        public Inventory()
        {
            products = new List<Product>();
        }
        public void AddProduct()
        {
            Console.WriteLine("Enter product name:");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            decimal price;
            while (
                !decimal.TryParse(Console.ReadLine(), out price)
            )
            {
                Console.WriteLine("Invalid price. Please enter a decimal number:");
            }
            Console.WriteLine("Enter product quantity:");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity. Please enter a whole number:");
            }
            Product product = new Product(name!, price, quantity);
            products.Add(product);
            Console.WriteLine("Product added successfully!");
        }
        public void DeleteProduct(String name)
        {
            Product? product = searchProduct(name);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($"Product '{name}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Product '{name}' not found.");
            }
        }
        public List<Product> GetProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
            }
            else
            {
                Console.WriteLine("Current products in inventory:");
                int index = 1;
                foreach (var product in products)
                {
                    Console.WriteLine($"{index}. {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                    index++;
                }
            }
            return products;
        }
        public void EditProduct(string name)
        {
            Product? product = searchProduct(name);
            if (product != null)
            {
                Console.WriteLine($"Product found: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");

                Console.WriteLine("Enter new name (or press Enter to keep current):");
                string? newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    product.Name = newName;
                }
                else
                {
                    Console.WriteLine("Keeping current name.");
                }

                Console.WriteLine("Enter new price (or press Enter to keep current):");
                string? priceInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(priceInput))
                {
                    if (decimal.TryParse(priceInput, out decimal newPrice))
                    {
                        product.Price = newPrice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Keeping current value.");
                    }
                }

                Console.WriteLine("Enter new quantity (or press Enter to keep current):");
                string? quantityInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(quantityInput))
                {
                    if (int.TryParse(quantityInput, out int newQuantity))
                    {
                        product.Quantity = newQuantity;
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Keeping current value.");
                    }
                }

                Console.WriteLine($"Product updated: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

        }
        public void SearchForProduct(string name)
        {
            Product? result = searchProduct(name);
            if (result != null)
            {
                Console.WriteLine($"Product found:");
                Console.WriteLine($"Name: {result.Name}, Price: {result.Price}, Quantity: {result.Quantity}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }


        public Product searchProduct(string name)
        {
            foreach (var p in products)
            {
                if (p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }
            return null!;
        }
    }
}