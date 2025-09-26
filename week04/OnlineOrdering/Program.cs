using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Console.WriteLine();


        Address address = new Address("254 Riverside Poblacion", "Kananga", "Leyte", "Philippines"); //creation of address
        Address address1 = new Address("366 Purok Kapayas", "Canjulao", "Cebu", "Philippines");
        Address address2 = new Address("1234 Buaya Street", "Salt Lake City", "UTAH", "USA");

        Customer customer = new Customer("Christopher Bahinting", address); //customer
        Customer customer1 = new Customer("Mercy Alburo", address1);
        Customer customer2 = new Customer("Juliet Jackson", address2);

        Product purpleCornJuice = new Product("Purple Corn Juice", "PCJ100", 4.50, 3);  //products with price and quantity
        Product purpleCornChocolate = new Product("Purple Corn Chocolate", "PCC200", 2.25, 5);
        Product purpleCornPowder = new Product("Purple Corn Powder", "PCP120", 100, 3);



        //ADDING PRODUCT TO LIST
        List<Product> products = new List<Product> { purpleCornJuice, purpleCornChocolate };
        List<Product> products1 = new List<Product> { purpleCornPowder, purpleCornChocolate };
        List<Product> products2 = new List<Product> { purpleCornPowder, purpleCornChocolate };

        //order
        Order order = new Order(products, customer);
        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);

        Console.WriteLine("CUSTOMER #1");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}"); //with two decimal places of prices

        Console.WriteLine();
        Console.WriteLine("CUSTOMER #2");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("CUSTOMER #3");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
        Console.WriteLine();
    }
}
        
    