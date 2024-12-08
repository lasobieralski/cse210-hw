using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Budget
{
    private decimal _monthlyLimit; // Encapsulation
    private decimal _currentSpending;
    private List<Expense> _expenses;

    // Constructor to initialize the budget
    public Budget(decimal monthlyLimit)
    {
        if (monthlyLimit <= 0)
        {
            throw new ArgumentException("Monthly limit must be greater than zero.");
        }
        _monthlyLimit = monthlyLimit;
        _currentSpending = 0;
        _expenses = new List<Expense>();
    }

    // Method to update the monthly limit
    public void SetMonthlyLimit(decimal newLimit)
    {
        if (newLimit <= 0)
        {
            throw new ArgumentException("Monthly limit must be greater than zero.");
        }
        _monthlyLimit = newLimit;
    }

    // Method to add an expense to the budget
    public void AddExpense(Expense expense)
    {
        if (expense == null)
        {
            throw new ArgumentNullException(nameof(expense), "Expense cannot be null.");
        }
        _expenses.Add(expense);
        _currentSpending += expense.Amount;
    }

    // Method to get the list of expenses (return a copy)
    public List<Expense> GetExpenses()
    {
        return new List<Expense>(_expenses);
    }

    // Method to remove an expense
    public void RemoveExpense(Expense expense)
    {
        if (expense == null)
        {
            throw new ArgumentNullException(nameof(expense), "Expense cannot be null.");
        }
        if (_expenses.Remove(expense))
        {
            _currentSpending -= expense.Amount;
        }
    }

    // Check if spending exceeds the budget
    public bool IsOverBudget()
    {
        return _currentSpending > _monthlyLimit;
    }

    // Generate a detailed budget report
    public string GenerateBudgetReport()
    {
        var report = new StringBuilder();
        report.AppendLine("Budget Report:");
        report.AppendLine($"Monthly Limit: {_monthlyLimit:C}");
        report.AppendLine($"Current Spending: {_currentSpending:C}");
        report.AppendLine($"Status: {(IsOverBudget() ? "Over Budget" : "Within Budget")}");
        report.AppendLine("Expenses:");
        foreach (var expense in _expenses)
        {
            report.AppendLine($"- {expense}");
        }
        return report.ToString();
    }

    // Method to get total expenses
    public decimal GetTotalExpenses()
    {
        return Math.Round(_currentSpending, 2);
    }

    // Method to get the count of expenses
    public int GetExpenseCount()
    {
        return _expenses.Count;
    }
}
