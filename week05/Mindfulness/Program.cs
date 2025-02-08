using System;

class Program
{
    static void Main(string[] args)
    {
        int userChoice = 0;
        while (userChoice != 4){

            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Start Breathing Activity");
            Console.WriteLine("\t2. Start Reflecting Activity");
            Console.WriteLine("\t3. Start Listing Activity");
            Console.WriteLine("\t4. Quit");
            Console.Write("Select a choice from the menu: ");

            bool isValid = int.TryParse(Console.ReadLine(), out userChoice);

            if (!isValid || userChoice < 1 || userChoice > 4){
                Console.WriteLine("Invalid choice....");
                continue;
            }

            switch (userChoice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case 4:
                Console.WriteLine("Thank you! Goodbye!");
                    break;
            }
        }

    }
}