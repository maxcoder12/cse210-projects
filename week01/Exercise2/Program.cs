using System;

class Program
{
    static void Main(string[] args)
    {
      Console.Write("What is your grade percentage?. In number please...");
      int gradePercentage = int.Parse(Console.ReadLine());
      string gradeLetter;
      string gradeSign;
      int gradePercentageRemainder = gradePercentage%10;
      bool passedCourse = true;

      if (gradePercentage >= 90)
      {
        gradeLetter = "A";
      } 
      else if(gradePercentage >= 80 && gradePercentage < 90)
      {
        gradeLetter = "B";
      }
      else if(gradePercentage >= 70 && gradePercentage < 80)
      {
        gradeLetter = "C";
      }
      else if (gradePercentage >= 60 && gradePercentage < 70)
      {
        gradeLetter = "D";
        passedCourse = false;
      }
      else
      {
        gradeLetter = "F";
        passedCourse = false;
      };

      if (gradePercentageRemainder >= 7)
      {
        gradeSign = "+";
      }
      else if (gradePercentageRemainder < 3)
      {
        gradeSign = "-";  
      }
      else
      {
        gradeSign = "";
      };
      
      if (passedCourse && (gradePercentage >= 70 && gradePercentage <= 93))
      {
        Console.Write($"Congratulation, you passed the course with a '{gradeLetter + gradeSign}' grade!!!");
      }
      else if (passedCourse == false && (gradePercentage < 70 && gradePercentage >= 60))
      {
        Console.Write($"Unfortunately, you failed the course with a '{gradeLetter + gradeSign}' grade.");
      }
      else
      {
        Console.Write($"Unfortunately, you failed the course with a '{gradeLetter}' grade.");
      };
      
    }
}