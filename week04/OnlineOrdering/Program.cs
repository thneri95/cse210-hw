using System;

class Program
{
    static void Main(string[] args)
    {

        // Greetings! 

        Console.WriteLine("=======================================");
        Console.WriteLine("     BYU Official Online Store");
        Console.WriteLine("=======================================\n");


        Console.WriteLine("Welcome to BYU Online Store Order System\n");
        Console.WriteLine("Thank you for shopping with us!");
        Console.WriteLine("Below is a summary of your recent orders:\n");



        // 1st Order
        Address address1 = new Address("123 Campus D", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("BYU Hoodie", "BYU101", 39.99, 2));
        order1.AddProduct(new Product("BYU T-Shirt", "BYU102", 19.99, 3));

        // 2nd Order
        Address address2 = new Address("456 Mission Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sister Lee", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("BYU Cap", "BYU201", 14.99, 1));
        order2.AddProduct(new Product("BYU Jacket", "BYU202", 59.99, 1));

        // Display:
        Console.WriteLine("Order #1:\n" + order1.GetOrderDetails());
        Console.WriteLine("\n----------------------------\n");
        Console.WriteLine("Order #2:\n" + order2.GetOrderDetails());
    }
}