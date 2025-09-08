using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
        Console.WriteLine();

        Job job1 = new Job();
        job1._companyName = "(Microsoft)";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2010;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._companyName = "(Apple)";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume resume = new Resume();
        resume._name = "Christopher Bahinting";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();

    }
}

