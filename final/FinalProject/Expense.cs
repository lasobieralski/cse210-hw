public class Expense
{
    public string Name { get; private set; }
    public decimal Amount { get; private set; }
    public string Category { get; private set; }

    public Expense(string name, decimal amount, string category)
    {
        Name = name;
        Amount = amount;
        Category = category;
    }

    public override string ToString()
    {
        return $"{Name}: {Amount:C} ({Category})";
    }
}
