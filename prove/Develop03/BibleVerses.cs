
namespace BibleMemory
{
//class #1 this is my scripture class
    public class BibleVerses //(scripture class this is the actual verse)
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
        public string GetScripture() => scripture;
        public List<string> GetVerseWords() => verses;
        
        
        //static method to get scripture List
        public static List<(string reference, string startText, string endText)> GetScriptureList()
        {
            return new List<(string reference, string startText, string endText)>
            {
                ("Psalm 46:10", "Be still, and know that I am God: I will be exalted among the heathen, I will be exalted in the earth.", null),
                ("Proverbs 3:5-6", "Trust in the Lord with all your heart;", "and lean not on your own understanding."),
                ("Isaiah 12:2", "Behold, God is my salvation; I will trust, and not be afraid: for the Lord Jehovah is my strength and my song; he also is become my salvation.", null)

            };
        }
    }
}