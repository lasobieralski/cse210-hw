namespace BibleMemory
{
    public class BibleText
    {
        private string scripture;
        private List<string> words;
        private List<int> hiddenWords = new List<int>();
        
        public BibleText(string scripture, List<string> words)
        {
            this.scripture = scripture;
            this.words = words;
        }

        public void DisplayVerse()
        {
            Console.Write(scripture + " ");
            for (int i = 0; i < words.Count; i++)
            {
                if (hiddenWords.Contains(i))
                    Console.Write("____ ");
                else
                    Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }

        public void RandomlyHideWords()
        {
            if (hiddenWords.Count == words.Count - 1)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    if (!hiddenWords.Contains(i))
                    {
                        hiddenWords.Add(i);
                        break;
                    }
                }
            }
            else
            {
                Random rand = new Random();
               
                int wordsToHide = rand.Next(2, 4); // Randomly choose 2 or 3 words to hide
    
                for (int i = 0; i < wordsToHide; i++)
                {
                    int index;
        
                    // Keep generating a random index until an unhidden word is found
                    do
                    {
                        index = rand.Next(words.Count);
                    } while (hiddenWords.Contains(index) && hiddenWords.Count < words.Count);

                    if (!hiddenWords.Contains(index))
                    {
                        hiddenWords.Add(index);
                    }
                    // Stop if all words are hidden
                    if (hiddenWords.Count == words.Count)
                        break;
                }
            }
        }
        // Check if the word is already hidden
        public bool IsFullyHidden()
        {
            return hiddenWords.Count == words.Count;
        }
    }
}
