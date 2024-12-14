using System;
using System.Collections.Generic;
public class Expense
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }

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
