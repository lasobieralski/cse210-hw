using System;
using System.Collections.Generic;

namespace BibleMemory
{
    class Program
    {
       static void Main(string[] args)
        {
            var scriptures = BibleVerses.GetScriptureList();

            // Select a random verse
            Random rand = new Random();
            int index = rand.Next(scriptures.Count);
            string scriptureReference = scriptures[index].reference;
            string startVerseText = scriptures[index].startText;
            string endVerseText = scriptures[index].endText;

            BibleVerses verseInstance = endVerseText != null
                ? new BibleVerses(scriptureReference, startVerseText, endVerseText)
                : new BibleVerses(scriptureReference, startVerseText);

            BibleText reference = new BibleText(verseInstance.GetScripture(), verseInstance.GetVerseWords());

            // Loop for hiding words until all are hidden
            while (true)
            {
                Console.Clear();
                reference.DisplayVerse();

                if (reference.IsFullyHidden())
                {
                    Console.WriteLine("All words have been hidden! Great job memorizing!");
                    break;
                }

                Console.WriteLine("Press Enter to hide words or type 'exit' to quit.");
                string input = Console.ReadLine();
                if (input?.ToLower() == "exit")
                    break;

                reference.RandomlyHideWords();
            }
        }
    }
}
 