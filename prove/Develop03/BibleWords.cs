//class #3
namespace BibleMemory
{
    public class BibleWords
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