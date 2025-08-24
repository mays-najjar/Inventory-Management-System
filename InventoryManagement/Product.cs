using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement;

public class Product
{
    private string name;
    private decimal price;
    private int quantity;

    public Product(string name, decimal price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}