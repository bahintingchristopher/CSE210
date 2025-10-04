using System;
using System.Threading;
using System.Collections.Generic;


public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
    }

    public void Run()
    {
        Start();
        GetRandomPrompt();
        Console.WriteLine("You may begin in: ");
        ShowCountdown(5);

        List<string> responses = GetListFromUser();
        _count = responses.Count;
        Console.WriteLine($"You listed {_count} items!");

        End();

    }
    private void GetRandomPrompt()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"[[{prompt}]]");
        Console.WriteLine();
        // Console.WriteLine("Press Enter when you are ready to begin...");
        // Console.ReadLine();
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
        }
        return responses;
    }
    //this code below is part of the additonal creativity
    public int GetCount()
    {
        return _count;
    }
}