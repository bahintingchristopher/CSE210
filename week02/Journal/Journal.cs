
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

//I added below with additional creativity of the program. 
//I added reminders for the users if the user has 
//not yet done creating Entry of the day.

public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
            entry.Display();
        Console.WriteLine();
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}~~{entry._promptText}~~{entry._entryText}");
            }
        }
        Console.WriteLine($"Journal save to {file}...");
    }


    public void LoadFromFile(string file)
    {
        _entries.Clear();

        if (!File.Exists(file))
        {
            Console.WriteLine($"File was not available: [{file}]");
            return;
        }

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~~");

            if (parts.Length == 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string entryText = parts[2];

                Entry entry = new Entry(prompt, entryText);
                entry._date = date;

                _entries.Add(entry);
            }
            else
            {
                Console.WriteLine($"Invalid line format; {line}");
            }
        }

        Console.WriteLine($"Journal loaded from {file}...");
    }


    //THIS LINE BELOW:
    //I added below with additional creativity of the program. 
    //I added reminders for the users if the user has 
    //not yet done creating Entry of the day.

    public DateTime? LastEntryDate
    {
        get
        {
            if (_entries.Count == 0) return null;
            return DateTime.Parse(_entries.Last()._date);
        }
    }

    public bool NeedsReminder()
    {
        var lastDate = LastEntryDate;
        if (lastDate == null) return true;
        return lastDate.Value.Date < DateTime.Now.Date;
    }

    public bool IsEmpty()
    {
        return _entries.Count == 0;
    }

}






