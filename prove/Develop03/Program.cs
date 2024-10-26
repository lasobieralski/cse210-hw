using System;
using System.Collections.Generic;
//stretch challenge
//I added a list of scriptures and used random to pull them for the
//user to memorize.
namespace BibleMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of scripture references.
            List<(string reference, string startText, string endText)> scriptures = new List<(string, string, string)>
            {
                ("Psalm 46:10", "Be still, and know that I am God: I will be exalted among the heathen, I will be exalted in the earth.", null),
                ("Proverbs 3:5-6", "Trust in the Lord with all your heart;", "and lean not on your own understanding."),
                ("Isaiah 12:2", "Behold, God is my salvation; I will trust, and not be afraid: for the Lord Jehovah is my strength and my song; he also is become my salvation.", null)
            };

            // Computer randomly selects a verse.
            Random rand = new Random();
            int index = rand.Next(scriptures.Count);  

            // Grab the scripture data.
            string scriptureReference = scriptures[index].reference;
            string startVerseText = scriptures[index].startText;
            string endVerseText = scriptures[index].endText;

            // Check what has been selected to debug the issue.
            Console.WriteLine($"Selected scripture: {scriptureReference}, verse text: {startVerseText}, end verse: {endVerseText}");

            // Verse range constructor
            BibleText reference;
            if (endVerseText != null)
            {
                BibleVerses verseRange = new BibleVerses(scriptureReference, startVerseText, endVerseText);
                reference = new BibleText(verseRange.GetScripture(), verseRange.GetText().Split(" ").ToList());
            }
            else
            {
                BibleVerses singleVerse = new BibleVerses(scriptureReference, startVerseText); 
                reference = new BibleText(singleVerse.GetScripture(), singleVerse.GetText().Split(" ").ToList());
            }

            BibleWords wordsInScripture = new BibleWords();

            // Enter loop for hiding words
            while (true)
            {
                // Clear the console and display the scripture
                Console.Clear();
                reference.DisplayVerse();

               
                if (reference.IsFullyHidden())
                {
                    Console.WriteLine("All words have been hidden! Good luck on you memorization!");
                    //Console.WriteLine("Reference: " + scriptureReference);  // Display reference
                    break;
                }

                Console.WriteLine("Press Enter to hide words or type 'exit' to quit.");
                string input = wordsInScripture.GetInput();
                if (wordsInScripture.CheckExitCondition(input))
                    break;
    
                    reference.RandomlyHideWords();

            }
        }
    }
}


