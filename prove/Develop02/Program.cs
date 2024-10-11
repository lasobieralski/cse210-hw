// I completed the basic requirements plus I personalized the journal 
// with user's name, indented it for better appearance. I added three journal
// types to choose from. I studied and learned from Gemini, chatGPT, and a Tutor.
using System;
using System.Collections.Generic;
using System.IO;
class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "Who are you? (Describe yourself.)",
        "Describe your family.",
        "How did you meet your companion?",
        "Tell us about your children.",
        "Describe you grandparents or an ancestor.",
        "What made you smile today?",
        "What did you do today?",
        "Who did you talk to today?",
        "What are your goals?",
        "What are you grateful for today?",
        "What miracles did you see today?",
        "What childhood memroies do you have?",
        "Who did you help along your path today?",
        "Who helped you along your path today?",
        "How have you seen God's Hand today?"
    };

    private Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

}

class Entry
{
    public string EntryText {get; set;}
    public DateTime Timestamp {get; set;}
    public Entry(string entryText)
    {
        EntryText = entryText;
        Timestamp = DateTime.Now;
    }
    public override string ToString()
    {
        return $"{Timestamp.ToString("g")}: {EntryText}";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private PromptGenerator promptGenerator;
    public Journal(PromptGenerator promptGenerator)
    {
        this.promptGenerator = promptGenerator;
    }

    public virtual void AddEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine("Journal Prompt: " + prompt);
        Console.WriteLine("Enter your response, then press enter:");
        string entryText = Console.ReadLine();

        Entry entry = new Entry(entryText);
        entries.Add(entry);
        Console.WriteLine("Nice job on your entry!");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }
    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();
        foreach (Entry entry in entries)
        {
            lines.Add($"{entry.Timestamp.ToString("o")}|{entry.EntryText}");
        }
        File.WriteAllLines(filename, lines);
        Console.WriteLine("Journal save successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                DateTime timestamp = DateTime.Parse(parts[0]);
                string entryText = parts[1];
                Entry entry = new Entry(entryText) {Timestamp = timestamp};
                entries.Add(entry);
            }

            Console.WriteLine("Your Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
class PersonalJournal : Journal
{
    public PersonalJournal(PromptGenerator promptGenerator) :base(promptGenerator)
    {

    }
    public override void AddEntry()
    {
        Console.WriteLine("This is your personal journal entry.");
        base.AddEntry();
    }
}
class MedicalJournal : Journal
{
    public MedicalJournal(PromptGenerator promptGenerator) :base(promptGenerator)
    {

    }
    public override void AddEntry()
    {
        Console.WriteLine("This is your medical journal entry.");
        base.AddEntry();
    }
}

class SpiritualJournal : Journal
{
    public SpiritualJournal(PromptGenerator promptGenerator) :base(promptGenerator)
    {

    }
    public override void AddEntry()
    {
        Console.WriteLine("This is your spiritual journal entry.");
        base.AddEntry();
    }
}
class Program
{
   static void Main(string[] args)
   {
        PromptGenerator promptGenerator = new PromptGenerator();
        
        Console.Write("Enter your full name, then press enter: "); 
        string userName = Console.ReadLine();
        Console.WriteLine("\nWelcome to My Journal");  //greeting
        Console.WriteLine($"    Written by {userName}"); //personalize the journal
        Console.WriteLine("Enter the type of journal you would like to use");
        Console.WriteLine("1. Personal Journal");
        Console.WriteLine("2. Medical Journal");
        Console.WriteLine("3. Spiritual Journal");
        string choose = Console.ReadLine();
        Journal journal = null;
        //Journal journal = new Journal(promptGenerator);
        switch (choose)
        {
            case "1":
                journal = new PersonalJournal(promptGenerator);
                break;
            case "2":
                journal = new MedicalJournal(promptGenerator);
                break;
            case "3":
                journal = new SpiritualJournal(promptGenerator);
                break;
            default:
                Console.WriteLine("Invalid choice, defaulting to personal journal.");
                journal = new PersonalJournal(promptGenerator);
                break;
        }
        journal.AddEntry();
        List<string> menuChoices = new List<string>
        {
            "1. Write in Journal",
            "2. Display Journal Entries",
            "3. Save Journal",
            "4. Load Journal",
            "5. Exit the Program",
        };

        while (true)
        {
            Console.WriteLine("Please select one of the following:");
            foreach(var choice in menuChoices)
            {
                Console.WriteLine(choice);
            }

            Console.Write("What would you like to do? (1-5)");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    journal.AddEntry(); //calls the method
                    break;
                case "2":
                    journal.DisplayEntries(); //calls the method
                    break;
                case "3":
                    Console.Write("Enter the filename to save, then press enter: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load, then press enter: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.Write("Happly writing! See you tomorrow!");
                    return;
                default:
                    Console.Write("Please select a number between 1-5.");
                    break;

            }
        }
   }

}



