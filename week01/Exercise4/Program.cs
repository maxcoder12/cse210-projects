using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int num = 1;
        int sum = 0;
        int largestNum = 0;
        int smallestNum = 1000;
        double averageNum = 0;

        while (num != 0)
        {
          Console.WriteLine("Enter a list of numbers, type 0 when finished");
          num = int.Parse(Console.ReadLine());

          if(num!=0){numbers.Add(num);};
        };

        for (int i = 0; i < numbers.Count; i++){
          sum += numbers[i];
          if (numbers[i] > largestNum)
          {largestNum = numbers[i];};
          if (numbers[i] < smallestNum && numbers[i] > 0){smallestNum = numbers[i];};
          averageNum = (double)sum / numbers.Count;
        };

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {averageNum:f3}");
        Console.WriteLine ($"The larger number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestNum}");
        Console.WriteLine($"The sorted list is: ");
        numbers.Sort();

        foreach (int number in numbers) {
          Console.WriteLine(number);
        };
    }
}