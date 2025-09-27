using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first order
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer cust1 = new Customer("Alice Johnson", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P001", 1200.50, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.99, 2));

        // Create second order
        Address addr2 = new Address("456 King St", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Bob Smith", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Headphones", "P010", 80.00, 1));
        order2.AddProduct(new Product("Keyboard", "P011", 55.75, 1));
        order2.AddProduct(new Product("Monitor", "P012", 200.00, 2));

        // Display results
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}\n");
    }
}