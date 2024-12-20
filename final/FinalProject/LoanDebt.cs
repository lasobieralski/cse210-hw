using System;
using System.Collections.Generic;
public class LoanDebt : Debt
{
    public int TermYears { get; set; }

    public LoanDebt(string name, decimal balance, decimal interestRate, int termYears)
        : base(name, balance, interestRate)
    {
        TermYears = termYears;
    }

    public override void MakePayment(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
            Balance -= amount;
    }

    public override decimal CalculateMonthlyInterest()
    {
        return Balance * InterestRate / 12;
    }

    public override string ToString()
    {
        return base.ToString() + $", Term: {TermYears} years";
    }
}