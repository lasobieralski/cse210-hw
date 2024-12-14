using System;
using System.Collections.Generic;
public class ReportGenerator
{
    public string GenerateFullReport(List<Expense> expenses, List<Debt> debts, decimal monthlyLimit)
    {
        decimal totalExpenses = 0;
        decimal totalDebts = 0;

        // Start building the report
        string report = "Full Budget Report\n";
        report += "------------------\n";
        report += $"Monthly Limit: {monthlyLimit:C}\n\n";

        report += "Expenses:\n";
        if (expenses.Count == 0)
        {
            report += "No expenses recorded.\n";
        }
        else
        {
            foreach (var e in expenses)
            {
                report += $"{e.Name}: {e.Amount:C} ({e.Category})\n";
                totalExpenses += e.Amount;
            }
        }

        report += $"\nTotal Expenses: {totalExpenses:C}\n";
        report += $"Remaining after Expenses: {monthlyLimit - totalExpenses:C}\n\n";

        report += "Debts:\n";
        if (debts.Count == 0)
        {
            report += "No debts recorded.\n";
        }
        else
        {
            foreach (var d in debts)
            {
                report += $"{d}\n";
                totalDebts += d.Balance;
            }
        }

        report += $"\nTotal Debts: {totalDebts:C}\n";

        // If you want to show the big picture net figure:
        // Net figure can be interpreted differently based on your needs.
        // For example, Monthly Limit - Expenses - Debts:
        decimal netFigure = monthlyLimit - totalExpenses - totalDebts;
        report += $"Net after Expenses and Debts: {netFigure:C}\n";

        return report;
    }

    public string GenerateExpenseReport(List<Expense> expenses)
    {
        if (expenses.Count == 0) return "No expenses to report.";

        decimal total = 0;
        string report = "Expense Report:\n";
        foreach (var e in expenses)
        {
            report += e.ToString() + "\n";
            total += e.Amount;
        }
        report += $"Total Expenses: {total:C}";
        return report;
    }

    public string GenerateDebtReport(List<Debt> debts)
    {
        if (debts.Count == 0) return "No debts to report.";

        string report = "Debt Report:\n";
        decimal totalBalance = 0;
        foreach (var d in debts)
        {
            report += d.ToString() + "\n";
            totalBalance += d.Balance;
        }
        report += $"Total Debt: {totalBalance:C}";
        return report;
    }
    
}