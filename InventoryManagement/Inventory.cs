using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Inventory
    {
        const int MinQuantity = 0;
        const decimal MinPrice = 0;
        private List<Product> products;

        public Inventory()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public bool DeleteProduct(String name)
        {
            Product? product = SearchProduct(name);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;

        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool EditProduct(string name, string? newName, decimal? newPrice, int? newQuantity)
        {
            Product? product = SearchProduct(name);
            if (product == null) return false;

            if (!string.IsNullOrWhiteSpace(newName))
                product.Name = newName;

            if (newPrice != null && newPrice >= MinPrice)
                product.Price = newPrice.Value;

            if (newQuantity != null && newQuantity >= MinQuantity)
                product.Quantity = newQuantity.Value;
                
            return true;
        }

        public Product? SearchProduct(string name)
        {
            return products.FirstOrDefault(p => p.Name == name);
        }
    }
}