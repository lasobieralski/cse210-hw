using System;
using System.Collections.Generic;
public class DemoData
{
    public void LoadDemo(Budget budget, List<Debt> debts)
    {
        // Setup Demo Budget
        budget.MonthlyLimit = 3000m;
        budget.AddExpense(new Expense("Groceries", 250m, "Food"));
        budget.AddExpense(new Expense("Electric Bill", 115m, "Utilities"));
        budget.AddExpense(new Expense("Cell Phone Bill", 35m, "Utilities"));
        budget.AddExpense(new Expense("Internet Bill", 50m, "Utilities"));
        budget.AddExpense(new Expense("Rent", 1495m, "Housing"));

        // Add Demo Debts
        debts.Add(new CreditCardDebt("Visa Platinum", 6500m, 0.18m));
        debts.Add(new CreditCardDebt("Shell Visa", 800m, 0.21m));
        debts.Add(new LoanDebt("Auto Loan (Nissan Rogue)", 25000m, 0.07m, 6));
        debts.Add(new LoanDebt("Student Loan", 35000m, 0.05m, 10));
    }
}
