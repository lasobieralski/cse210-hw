using System;
using System.Collections.Generic;
public class CreditCardDebt : Debt
{
    public CreditCardDebt(string name, decimal balance, decimal interestRate)
        : base(name, balance, interestRate)
    { }

    public override void MakePayment(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
            Balance -= amount;
    }

    public override decimal CalculateMonthlyInterest()
    {
        return Balance * InterestRate / 12;
    }
}
