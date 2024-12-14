using System;
using System.Collections.Generic;
public class Budget
{
    private decimal monthlyLimit;
    private List<Expense> expenses;

    public Budget(decimal monthlyLimit)
    {
        this.monthlyLimit = monthlyLimit;
        this.expenses = new List<Expense>();
    }

    public decimal MonthlyLimit
    {
        get { return monthlyLimit; }
        set
        {
            if (value >= 0)
                monthlyLimit = value;
        }
    }

    public void AddExpense(Expense expense)
    {
        expenses.Add(expense);
    }

    public void RemoveExpense(Expense expense)
    {
        expenses.Remove(expense);
    }

    public List<Expense> GetExpenses()
    {
        return new List<Expense>(expenses);
    }

    public decimal GetTotalExpenses()
    {
        decimal total = 0;
        foreach (var e in expenses)
            total += e.Amount;
        return total;
    }
}
