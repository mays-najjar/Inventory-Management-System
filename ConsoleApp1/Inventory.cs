using System;
using System.Collections.Generic;
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
    }
}