using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade perecentage? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 93)
        {
            letter = "A";
        }

        else if (percent >= 90)
        {
            letter = "A-";
        }

        else if (percent >= 80)
        {
            letter = "B";
        }

        else if (percent >= 70)
        {
            letter = "C";
        }

        else if (percent >= 60)
        {
            letter = "D";
        }

        else  
        {
            letter = "F";
        }


        int lastDigit = percent % 10;

        if (letter != "F" && letter != "A" && letter != "A-")
        {
            if (lastDigit >= 7)
            {
                letter += "+";
            }
            else if (lastDigit < 3)
            {
                letter += "-";
            }
        }

        Console.WriteLine($"Your Letter grade is {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }

        else
        {
            Console.WriteLine("Sorry you had not passed! Be prepare for the next time.");
        }















    }
}