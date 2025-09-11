using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        Console.WriteLine();
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();


        //creativity added here, to help the user about the journal entry of the day, it gives immediate 
        //idea about his/her Journal Entry of the day. If the user is having a forgetfulnes, the app have a 
        //quick access to the latest Entry Date upon opening his/her app. and also gives reminders if no entry have been done yet. 
        string[] txtFiles = Directory.GetFiles(".", "*.txt");
        string[] noExtFiles = Directory.GetFiles(".")
            .Where(f => string.IsNullOrEmpty(Path.GetExtension(f)))
            .ToArray();

        string[] journalFiles = txtFiles.Concat(noExtFiles).ToArray();
        
        if (journalFiles.Length > 0)
            {
                string latestFile = journalFiles
                    .OrderByDescending(f => File.GetLastWriteTime(f))
                    .First();

                journal.LoadFromFile(latestFile);
                // Console.WriteLine($"Journal loaded from  {latestFile}...");

                if (journal.LastEntryDate != null)
                {
                    Console.WriteLine($"Your last Journal Entry was on {journal.LastEntryDate.Value.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("You dont have Journal Entry yet for today.");
                }
                if (journal.NeedsReminder())
                {
                    Console.WriteLine("Have you done creating journal entry today? Please make Entry even with simple one!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("YOu dont have any Journal Files yet.");
            }
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1.) Write");
            Console.WriteLine("2.) Display");
            Console.WriteLine("3.) Load");
            Console.WriteLine("4.) Save");
            Console.WriteLine("5.) Quit");
            Console.Write("What would you like to do? ");

            String choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompts();
                Console.WriteLine($"PROMPT: {prompt}");
                Console.WriteLine("RESPONSE:");
                string entryText = Console.ReadLine();

                Entry entry = new Entry(prompt, entryText);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {

                if (journal.IsEmpty())
                {
                    Console.WriteLine("No Entries to be save, Please write something first.");
                }

                else
                {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                }
            }

            else if (choice == "5")
            {
                Console.WriteLine("Thank you! Bye-Bye!");
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice, pleae try again.");
            }

        }
    }
}
