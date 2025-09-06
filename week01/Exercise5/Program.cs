using System;
using System.ComponentModel;

class Program
{

static void Main(string[] args)
    {

        Console.WriteLine();
        //this area were calling the displaywelcomemessage 
        displayWelcomeMessage();


        //call the user's input
        string userName = PromptUsername();
        int desiredNumber = PromptUserNumber();


        //calculate the square
        int squaredValue = SquareNumbers(desiredNumber);

        //display the result
        DisplayResult(userName, squaredValue);
    }



    //welcome message
    static void displayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    //ask the user to enter his/her name
    static string PromptUsername()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    //function to the user to enter the favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }


    //calculate the number and find the squared
    static int SquareNumbers(int number)
    {
        return number * number;
    }

    //display the result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }


    //main method
    


}










