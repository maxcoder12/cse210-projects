using System;

class Program
{
    static void Main(string[] args)
    {
      Random randomGenerator = new Random();
      int userGuess;
      Console.WriteLine("Do you want to play the Magic Number game?");
      string userReponse = Console.ReadLine();
      while (userReponse == "yes")
      {
        int attemps = 0;
        int magicNumber = randomGenerator.Next(1, 10);
        Console.WriteLine("What is the magic number?");
        do 
        {
        Console.Write("What is your guess? ");
        userGuess = int.Parse(Console.ReadLine());

        if (userGuess < magicNumber)
        {
          Console.WriteLine("Higher");
          attemps++;
          Console.WriteLine($"Attemps: {attemps}");
        }
        else if (userGuess > magicNumber)
        {
          Console.WriteLine("Lower");
          attemps++;
          Console.WriteLine($"Attemps: {attemps}");
        }
        else
        {
          Console.WriteLine($"You guessed it! The magic number was {userGuess}");
          attemps++;
          Console.WriteLine($"Attemps: {attemps}");
          Console.WriteLine("Do you want to continue playing the Magic Number game?");
          userReponse = Console.ReadLine();
        };
        } while (userGuess != magicNumber);
      };

      Console.WriteLine("Good game! Bye!");
    }
}