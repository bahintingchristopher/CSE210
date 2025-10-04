using System;
using System.Threading;
using System.Collections.Generic;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        SetDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);

        Console.Clear();
    }

    private void SetDuration()
    {
        Console.Write("How long, in seconds, would you like for your sessions? ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out _duration) && _duration > 0)
            {
                break;
            }
            else
            {
                Console.Write("Please enter a valid positive integer for the duration: ");
            }
        }
    }
    // Original spinner method
    // protected void ShowSpinner(int seconds)
    // {
    //     List<string> animationStrings = new List<string>();
    //     animationStrings.Add("|");
    //     animationStrings.Add("/");
    //     animationStrings.Add("-");
    //     animationStrings.Add("\\");
    //     animationStrings.Add("|");
    //     animationStrings.Add("/");
    //     animationStrings.Add("-");
    //     animationStrings.Add("\\");
    //     DateTime endTime = DateTime.Now.AddSeconds(seconds);
    //     int i = 0;

    //     while (DateTime.Now < endTime)
    //     {
    //         Console.Write(animationStrings[i % animationStrings.Count]);
    //         Thread.Sleep(1000);
    //         Console.Write("\b \b");
    //         i++;
    //     }

    protected void ShowSpinner(int seconds)
    {
        int length = 20;    //THIS IS THE WIDTH OF THE SNAKE       
        int snakeLength = 5;      //THIS THE NUMBER OF 'o's IN THE SNAKE 
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int position = 0;
        int direction = 1;

        while (DateTime.Now < endTime)
        {
            char[] line = new char[length];
            for (int i = 0; i < length; i++)
                line[i] = ' ';


            for (int i = 0; i < snakeLength; i++)
            {
                int idx = position + i;

                // Make sure we don’t go outside the bounds
                if (idx >= length)
                    break;

                line[idx] = 'o';
            }

            Console.Write(new string(line));
            Thread.Sleep(20);
            Console.Write("\r");

            position += direction;


            if (position <= 0 || position >= length - snakeLength)
                direction *= -1;
        }
        Console.Write(new string(' ', length) + "\r");


    }
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    //this code below is part of the additonal creativity
    public int GetDuration()
    {
        return _duration;
    }
}
