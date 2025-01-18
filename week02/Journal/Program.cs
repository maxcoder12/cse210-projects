using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        Console.WriteLine("Welcome to the Journal Program!");
        int userOption = 0;
    
        while (userOption != 6){
        
        
          Console.WriteLine("Please select an option:");
          Console.WriteLine("1. Write");
          Console.WriteLine("2. Display");
          Console.WriteLine("3. Load");
          Console.WriteLine("4. Save");
          Console.WriteLine("5. Clear");
          Console.WriteLine("6. Quit");
          Console.Write("What would you like to do?");
          userOption = Convert.ToInt32(Console.ReadLine());
    
          switch (userOption) 
          {
            case 1: 
              string date = DateTime.Now.ToShortDateString();
              string promptText = promptGenerator.GetRandomPrompt();
              Console.WriteLine(promptText);
              string entryText = Console.ReadLine();
                
              journal.AddEntry(date, promptText, entryText);
              break;
            case 2: 
              journal.DisplayAll();
              break;
            case 3:
              journal.LoadFromFile("journal.txt"); 
              break;
            case 4:
              journal.SaveToFile("journal.txt");
              break;
            case 5:
              journal.ClearFile("journal.txt");
              break;
            case 6:
              Console.WriteLine("Thank you! Goodbye! :)");
              break;
            default:
              Console.WriteLine("Invalid option. Please try again.");
              break;
          }
        }
    }
}