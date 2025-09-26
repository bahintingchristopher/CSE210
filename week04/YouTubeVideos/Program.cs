using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");


        //creation of address
        Address address = new Address("254 Riverside Poblacion", "Kananga", "Leyte", "Philippines");

        //customer
        Customer customer = new Customer("Christopher Bahinting", address);

        //products
        Product purpleCornJuice = new Product("Purple Corn Juice", "PCJ100", 4.50, 3);
        Product purpleCornChocolate = new Product("Purple Corn Chocolate", "PCC200", 2.25, 5);

        //ADDING PRODUCT TO LIST
        List<Product> products = new List<Product> { purpleCornJuice, purpleCornChocolate };

        //order
        Order order = new Order(products, customer);

        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
    }
}