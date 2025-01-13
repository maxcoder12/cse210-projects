using System;

class Program
{
    static void DisplayWelcome()
    {
      Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
      Console.WriteLine("Please enter your name:");
      string name = Console.ReadLine();

      return name;
    }

    static int PromptUserNumber()
    {
      Console.WriteLine("Please enter your favorite number:");
      int number = int.Parse(Console.ReadLine());
      return number;
    }

    static int SquareNumber(int number)
    {
      int square = number * number;  
      return square;
    }

    static void DisplayMessage(string name, int number, int square)
    {
      Console.WriteLine($"Hello {name}, the square of your favorite number: '{number}', is {square}.");
    }

    static void DisplayGoodbye()
    {
      Console.WriteLine("Thank you! Goodbye!");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayMessage(name, number, square);
        DisplayGoodbye();
    }
}