using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job(); 
        job1._company = "Google";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2018;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._company = "Microsoft";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2023;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Maximo Gomez";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}