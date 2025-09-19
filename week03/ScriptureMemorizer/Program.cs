using System;

// I added additional creativity of the program below, I added code that the user sees the elapsed time  and know how long they took to memorize the scripture and the number of pressing the enter key is counted as attempts.
class Program
{
    static void Main(string[] args)
    {
       

        var reference = new Reference("1 Nephi", 3, 7);
        var scripture = new Scripture(reference,
             "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");


        int enterKey = 0;
        DateTime startTime = DateTime.Now;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello World! This is the ScriptureMemorizer Project."); //I transferred this line here because it is deleted by "clear console" code  if this is put on top.
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.isCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Congratulations! You have memorized the scripture!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("Thank you for your time. Goodbye!");
                break;
            }
            enterKey++; // Count how many times words have been hidden
            scripture.HideRandomWords(4);
        }
        //below this line, added the creativity of the program. 
        //the number of pressing the Enter key is counted as attempts and the time taken to memorize the scripture is calculated.
        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        Console.WriteLine($"\nYou took {enterKey} times pressing the Enter Key to memorize the scripture.");
        Console.WriteLine($"You made it with {duration.Minutes} minutes and {duration.Seconds} seconds!");
        Console.WriteLine("You want to beat that record?just restart the program and try again and see if you can do i more faster!");
        Console.WriteLine();
    }
}