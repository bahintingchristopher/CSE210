using System;
using System.Collections.Generic; // for use in generic collection like list<int>
using System.Linq; //to calculate the min

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        Console.WriteLine();

        List<int> numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);


            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        if (numbers.Count > 0)
        {

            //compute the sum
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is : {sum}");


            //compute the average
            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            //find the max number
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"The largest number is:  {max}");

            //finding the smallest numbes
            var positiveNumbers = numbers.Where(n => n > 0).ToList();
            if (positiveNumbers.Count > 0)
            {
                int smallestPositive = positiveNumbers.Min();
                Console.WriteLine($"The smallest positive numbers is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers entered");
            }

            //sorting the list and display
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers) 
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}