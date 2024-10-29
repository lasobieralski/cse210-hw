//class #3
namespace BibleMemory
{
    public class BibleWords //this represents the words in the text
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
        public bool CheckExitCondition(string input)
        {
            return input.ToLower() == "exit";
        }
        public bool IsEnterKeyPressed(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}