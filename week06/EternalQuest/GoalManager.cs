using System;
using System.Collections.Generic;
using System.IO;


public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        Console.WriteLine("Welcome to Eternal Quest...!");
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYou have: {_score} points.\n");

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nTypes of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which Type of Goal you want to create?  ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of Your Goal? ");
        string name = Console.ReadLine();

        Console.Write("What is the Description of it?  ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this Goal?  ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points input");
            return;
        }

        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter the number of times to complete (target): ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target input");
                    return;
                }
                Console.Write("Enter bonus points for completing checklist goal: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus input.");
                    return;
                }
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet.");
            return;
        }
        Console.WriteLine("\nGoals:");

        int index = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to Record");
            return;
        }

        Console.WriteLine("\nWhich goal did you complete?");
        int index = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{index}.{goal.Name}");
            index++;
        }

        Console.Write("Enter goal number:");
        if (!int.TryParse(Console.ReadLine(), out int goalNumber) || goalNumber < 1 || goalNumber > _goals.Count)
        { //TryParse is to convert string to other data type
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];
        int pointsEarned = selectedGoal.RecordEvent();

        if (pointsEarned > 0)
        {
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points.");
            Console.WriteLine($"You have now {_score} points.");
        }
        else
        {
            Console.WriteLine("No points earned (goal may already be complete).");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save goals:");
        string filename = Console.ReadLine();

       
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex) //exception handling
        {
            Console.WriteLine($"Error saving goals:{ex.Message}");
        }
    }
    
    private void LoadGoals()
    {
        Console.Write("Enter filename to load goals:");
        string filename = Console.ReadLine();

      
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            _score += int.Parse(lines[0]);//add the previous score
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                Goal goal = ParseGoalFromString(lines[i]);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals:{ex.Message}");
        }
    }

           private Goal ParseGoalFromString(string data)
            {
        string[] parts = data.Split(',');

        try
        {
            switch (parts[0])
            {
                case "SimpleGoal":
                    var simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    bool isComplete = bool.Parse(parts[4]);
                    if (isComplete)
                    {
                        simpleGoal.RecordEvent();
                    }

                    return simpleGoal;

                case "EternalGoal":
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));

                case "ChecklistGoal":
                    var checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));

                    for (int c = 0; c < int.Parse(parts[4]); c++)
                    {
                        checklistGoal.RecordEvent();
                    }
                    return checklistGoal;

                default:
                    return null;
            }
        }
        catch
        {
            Console.WriteLine("Failed to parse goal from file.");
            return null;
        }
    }
}

