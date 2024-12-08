using System;
using System.Collections.Generic;
using System.Text;

public class ReportGenerator
{
    public string GenerateExpenseReport(List<Expense> expenses)
    {
        if (expenses == null || expenses.Count == 0)
        {
            return "Expense Report:\nNo expenses to display.\n";
        }

        StringBuilder report = new StringBuilder("Expense Report:\n");
        decimal totalExpenses = 0;

        foreach (var expense in expenses)
        {
            report.AppendLine(expense.ToString()); // Append expense details
            totalExpenses += expense.Amount; // Add to total expenses
        }

        report.AppendLine($"Total Expenses: {totalExpenses:C}"); // Format total as currency
        return report.ToString(); // Return final report as a string
    }

    public string GenerateDebtReport(List<Debt> debts)
    {
        if (debts == null || debts.Count == 0)
        {
            return "Debt Report:\nNo debts to display.\n";
        }

        string report = "Debt Report:\n";
        foreach (var debt in debts)
        {
            report += debt.ToString() + "\n";

            if (debt is LoanDebt loan)
            {
                report += loan.GenerateDetailedLoanReport() + "\n";
            }
        }

    return report;
    }
}