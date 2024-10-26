
namespace BibleMemory
{
//class #1
    public class BibleVerses
    {
        private string scripture;
        private List<string> verses;
        public BibleVerses(string scripture, string verseText)
        {
            this.scripture = scripture;
            this.verses = new List<string>(verseText.Split(" "));
        }
        public BibleVerses(string scripture, string startVerseText, string endVerseText)
        {
            this.scripture = scripture;
            string combinedVerses = startVerseText + " " + endVerseText;
            this.verses = new List<string>(combinedVerses.Split(" "));
        }
        public string GetScripture()
        {
            return scripture;
        }
    //public List<string> GetReference()
    //{
        //return verses;
    //}
        public string GetText()
        {
            return string.Join(" ", verses);
        }
    }
}