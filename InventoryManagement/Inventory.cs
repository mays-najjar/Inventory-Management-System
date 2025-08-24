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
            Product? product = searchProduct(name);
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
            {
                Product? product = searchProduct(name);
                if (product == null) return false;

                if (!string.IsNullOrWhiteSpace(newName))
                    product.Name = newName;

                if (newPrice != null && newPrice >= 0)
                    product.Price = newPrice.Value;

                if (newQuantity != null && newQuantity >= 0)
                    product.Quantity = newQuantity.Value;

                return true;

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