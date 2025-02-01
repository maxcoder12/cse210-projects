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

        Address address = new Address(street, city, state, country);

        Customer customer = new Customer(username, address);


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

        Order order = new Order(userOrder, customer);

        int userOption = 0;
        while (userOption != 5)
        {
            Console.Clear();
            int i = 0;

            Console.WriteLine("Shopping Cart.");
            foreach (Product product in productsCart){
                i++;
                string productInfo = $"{i}. Product: {product.GetName()} - Price: {product.GetPrice()}";

                Console.WriteLine(productInfo);
            }

            Console.WriteLine("\nSelect one of the following options:");
            Console.WriteLine("1. Add Item.");
            Console.WriteLine("2. Remove Item.");
            Console.WriteLine("3. See current order.");
            Console.WriteLine("4. Finish order.");
            Console.WriteLine("5. Quit.");

            userOption =  int.Parse(Console.ReadLine());

            if(userOption == 1)
            {
                Console.WriteLine("Select one of the products by their indexes. (E.g : 1)");
                int itemIndex = int.Parse(Console.ReadLine());
                itemIndex -= 1;

                string itemName = productsCart[itemIndex].GetName();
                int itemID = productsCart[itemIndex].GetProductID();
                double itemPrice = productsCart[itemIndex].GetPrice();
                int itemQuantity = 0;

                Console.WriteLine("How many do you want?");
                itemQuantity = int.Parse(Console.ReadLine());

                Product item = new Product(itemName, itemID, itemPrice, itemQuantity);

                Console.WriteLine($"You ordered: {itemQuantity} - {itemName} | 1un = {itemPrice} x {itemQuantity} = {item.CalculateTotalPrice()}");
                Console.WriteLine($"Do you want to confirm? Y / N");
                string userConfirm = Console.ReadLine();

                if (userConfirm.ToLower() == "y"){
                    userOrder.Add(item);
                } else {
                    continue;
                }
            } 
            else if (userOption == 2)
            {
                i = 0;
                Console.WriteLine("Your Order:");
                foreach (Product product in userOrder){
                    i++;
                    string productInfo = $"{product.GetProductID()} - {product.GetName()} | 1un = ${product.GetPrice()} x {product.GetQuantity()} = ${product.CalculateTotalPrice()}";

                    Console.WriteLine(productInfo);
                }

                Console.WriteLine("Select one of the products by their indexes. (E.g : 1)");
                int itemIndex = int.Parse(Console.ReadLine());
                itemIndex -= 1;

                string itemName = userOrder[itemIndex].GetName();
                int itemID = userOrder[itemIndex].GetProductID();
                double itemPrice = userOrder[itemIndex].GetPrice();
                int itemQuantity = userOrder[itemIndex].GetQuantity();

                Console.WriteLine("How many do you want to remove?");
                int itemQuantityRemove = int.Parse(Console.ReadLine());

                if (itemQuantityRemove == itemQuantity){
                    Console.WriteLine($"You want to remove: {itemQuantity} - {itemName} | 1un = ${itemPrice} x {itemQuantity} = ${item.CalculateTotalPrice()}");
                } else if (itemQuantityRemove < itemQuantity){
                    Console.WriteLine($"You want to remove: {itemQuantityRemove} - {itemName} | 1un = ${itemPrice} x {itemQuantity} = ${item.CalculateTotalPrice()}");
                } else{
                    Console.WriteLine("Invalid number");
                    continue;
                }
                Console.WriteLine($"Do you want to confirm? Y / N");
                string userConfirm = Console.ReadLine();

                if (userConfirm.ToLower() == "y" && itemQuantity == itemQuantityRemove){
                    userOrder.RemoveAt(itemIndex);
                } else if (userConfirm.ToLower() == "y" && itemQuantityRemove < itemQuantity){
                    userOrder[itemIndex].SetQuantity(itemQuantity - itemQuantityRemove);
                } else{
                    Console.WriteLine("Invalid option.");
                    continue;
                }
            }
            else if (userOption == 3)
            {
                i = 0;
                Console.WriteLine("Your order:");
                foreach (Product product in userOrder){
                    i++;
                    string productInfo = $"{product.GetProductID()} - {product.GetName()} | 1un = ${product.GetPrice()} x {product.GetQuantity()} = ${product.CalculateTotalPrice()}";

                    Console.WriteLine(productInfo);
                }
            }
            else if (userOption == 4)
            {
                Console.WriteLine(order.DisplayShippingLabel());
                Console.WriteLine("Your order:");
                Console.WriteLine(order.DisplayPackingLabel());
                Console.WriteLine("There is a $35 shipping tax for whom doesn't live in USA, whom does a $5 shipping  tax will be applied.");
                Console.WriteLine("Total Cost:");
                Console.WriteLine(order.GetTotalCost());

                Console.WriteLine("Do you want to finished? Y / N");
                string userFinish = Console.ReadLine();

                if (userFinish.ToLower() == "y"){
                    Console.WriteLine("Transaction Succesfully finished!");
                    Console.WriteLine("Goodbye!");
                    break;
                } else if (userFinish.ToLower() == "n"){
                    continue;
                } else{
                    Console.WriteLine("Invalid Option...");
                    continue;
                }
            } else if (userOption == 5)
            {
                Console.WriteLine("Goodbye!!");
                break;
            } else
            {
                Console.WriteLine("Invalid Option...");
                continue;
            }

        }        
    }
}