using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
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
        public void DeleteProduct(Product product)
        {
            products.Remove(product);
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
            bool productFound = false;
            foreach (var p in products)
            {
                if (!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(name.ToLower()))

                {
                    productFound = true;
                    Console.WriteLine($"Product found: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
                    Console.WriteLine("Enter new name (or press Enter to keep current):");
                    string? newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        p.Name = newName;
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
                            p.Price = newPrice;
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
                            p.Quantity = newQuantity;
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity. Keeping current value.");
                        }
                    }
                    
                    Console.WriteLine($"Product edited: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
                    Console.WriteLine("Product updated successfully!");
                }

            }
            if (!productFound)
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}