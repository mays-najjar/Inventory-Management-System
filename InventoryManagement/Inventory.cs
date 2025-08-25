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
            else
            {
                return false;
            }
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

            const decimal MinPrice = 0;

            if (newPrice != null && newPrice >= MinPrice)
                product.Price = newPrice.Value;

            const int MinQuantity = 0;

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