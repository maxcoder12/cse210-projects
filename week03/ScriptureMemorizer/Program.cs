using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write the name of the book");
        string book = Console.ReadLine();
    
        Console.WriteLine("Write the number of the chapter");
        int chapter = Convert.ToInt32(Console.ReadLine());
    
        Console.WriteLine("Write the number of the verse");
        int verse = Convert.ToInt32(Console.ReadLine());
    
        Console.WriteLine("Write the number of the end verse. If doesnt have an end verse, write 0");
        int endVerse = Convert.ToInt32(Console.ReadLine());
    
        Console.WriteLine("Write the text of the scripture");
        string originalText = Console.ReadLine();
    
        Reference reference;
    
        if (endVerse == 0){
          reference = new Reference(book, chapter, verse);
        } else{
          reference = new Reference(book, chapter, verse, endVerse);
        }
    
        Scripture scripture = new Scripture(reference, originalText);
    
        string userOption = "";
    
        while (userOption == ""){
          Console.Clear();
          
          if (scripture.IsCompletelyHidden())
          {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("All words are hidden. The program ended.");
            break;
          }
          
          Console.WriteLine(scripture.GetDisplayText());
    
          Console.WriteLine("Type Enter to continue or 'Quit' to end the program.");
          userOption = Console.ReadLine();
    
          if (userOption == "")
          {
            scripture.HideRandomWords(2);
          }
          else if(userOption == "Quit")
          {
            Console.WriteLine("Thank you! Goodbye!");
            break;
          }
          else{
            continue;
          }
        }
    
        Console.WriteLine("Do you want to see the scripture again? Type 'Yes' or 'No'.");
        userOption = Console.ReadLine();
    
        if (userOption.ToLower() == "yes"){
          scripture = new Scripture(reference, originalText);
          Console.WriteLine(scripture.GetDisplayText());
        }else{
          Console.WriteLine("Thank you! Goodbye!");
        }
    }
}