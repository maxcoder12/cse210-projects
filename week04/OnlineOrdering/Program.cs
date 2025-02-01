using System;

class Program
{
    static void Main(string[] args)
    {     
        Console.WriteLine("Welcome to the Shopping Cart!");
        Console.WriteLine("What is your name?");
        string username = Console.ReadLine();

        Console.WriteLine("Type the name of your street: ");
        string street = Console.ReadLine();
        Console.WriteLine("City:");
        string city = Console.ReadLine();
        Console.WriteLine("State:");
        string state = Console.ReadLine();
        Console.WriteLine("Country:");
        string country = Console.ReadLine();

        Address address = new Adresss(street, city, state, country);

        Customer customer = new Customer(username, address);

        Order order = new Order(userOrder, customer);

        List<Product> productsCart = new List<Product>
        {
            new Product("Smartphone Case", 748392, 12.99, 0),
            new Product("Wireless Bluetooth Headphones", 283640, 49.99, 0),
            new Product("4K Ultra HD TV", 592740, 799.99, 0),
            new Product("Yoga Mat", 124853, 22.50, 0),
            new Product("Gaming Mouse", 937820, 29.99, 0),
            new Product("Electric Coffee Maker", 483920, 49.00, 0),
            new Product("LED Desk Lamp", 930184, 19.99, 0),
            new Product("Portable Power Bank", 182736, 29.99, 0),
            new Product("Leather Wallet", 748201, 39.99, 0),
            new Product("Bluetooth Speaker", 374820, 59.99, 0)
        };

        List<Product> userOrder = new List<Product>();

        int userOption = 0;
        while (userOption != 4){
            Console.Clear();

            Console.WriteLine("Shopping Cart.")
            foreach (Product product in productsCart){
                int i = 1;
                string productsInfo = $"Product: {product.GetName()} - Price: {product.GetPrice()}";

                Console.WriteLine(productInfo);
                i++;
            }

            Console.WriteLine("Select one of the following options:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item.");
            Console.WriteLine("3. See current order.")
            Console.WriteLine("4. Finish order");

            userOption =  int.Parse(Console.ReadLine());

            if(userOption == 1){

            }

        }        
    }
}