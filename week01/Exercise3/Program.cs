using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        //while loop

        bool playAgain = true;

        while (playAgain)
        {

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = 0;
            int attemptCount = 0;

            Console.WriteLine("\n Guess the Magic Number from 1 - 100.");

            while (guess != magicNumber)

            {
                Console.Write("What is your magic number? ");
                string Input = Console.ReadLine();


                if (int.TryParse(Input, out guess))
                {

                    attemptCount++;

                    if (magicNumber > guess)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (magicNumber < guess)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine($"Your got it by {attemptCount} attempts.");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a valid number from 1-100.");
                }
            }



            Console.Write("Do you want to play again? ");
            string response = Console.ReadLine().Trim().ToLower();

            if (response != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thank you for playing with us!");
            }
        }

        
        




    }
}