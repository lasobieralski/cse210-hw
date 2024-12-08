public class Category
{
    public string Name { get; private set; }
    private List<Expense> _expenses;

    public Category(string name)
    {
        Name = name;
        _expenses = new List<Expense>();
    }

    public void AddExpense(Expense expense)
    {
        if (expense.Category == Name)
        {
            _expenses.Add(expense);
        }
    }

    public decimal GetTotalSpent()
    {
        decimal total = 0;
        foreach (var expense in _expenses)
        {
            total += expense.Amount;
        }
        return total;
    }
    public List<Expense> GetExpenses()
    {
        return _expenses;
    }

    public override string ToString()
    {
        return $"{Name} - Total Spent: {GetTotalSpent():C}";
    }

}
