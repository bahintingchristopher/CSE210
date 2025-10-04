using System;
using System.IO;

class Program
{
    //

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.Run();
                        //this "log" code below is part of the additonal creativity
                        log("breathingActivity", $"Completed {breathingActivity.GetDuration()} seconds.");
                        break;
                    case 2:
                        ReflectingActivity reflectingActivity = new ReflectingActivity();
                        reflectingActivity.Run();
                        //this "log" code below is part of the additonal creativity
                        log("reflectingActivity", $"Completed {reflectingActivity.GetDuration()} seconds.");
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.Run();
                        //this "log" code below is part of the additonal creativity
                        log("listingActivity", $"Listed {listingActivity.GetCount()} items in {listingActivity.GetDuration()} seconds.");
                        break;
                    case 4:
                        Console.WriteLine("Thank you and Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please select a valid option (1-4).");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number corresponding to the menu options.");
            }
        }



    }

    //this code below is part of the additonal creativity
    //the program has the ability to log each activity with a timestamp to a text file
    //the log file is named "Mindfulness_ctivity_log.txt"
     private static readonly string logFilePath = "MindfulnessActivityLog.txt";

    public static void log(string activityName, string message)
    {
        string logEntry = $"{DateTime.Now}: [{activityName}] {message}";
        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
    }

}   