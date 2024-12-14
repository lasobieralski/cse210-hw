using System;
using System.Collections.Generic;
public abstract class Debt
{
    public string Name { get; set; }
    public decimal Balance { get; protected set; }
    public decimal InterestRate { get; set; }

    public Debt(string name, decimal balance, decimal interestRate)
    {
        Name = name;
        Balance = balance;
        InterestRate = interestRate;
    }
    public abstract void MakePayment(decimal amount);
    public abstract decimal CalculateMonthlyInterest();
    public override string ToString()
    {
        return $"{Name}: Balance {Balance:C}, Rate {InterestRate:P}";
    }
}
