using System;
using System.Collections.Generic;

public abstract class Debt
{
    private decimal _balance;
    private decimal _interestRate;
    private List<string> _paymentHistory = new List<string>(); // Store payment history

    // Public properties for accessing balance and interest rate
    public decimal Balance => _balance;
    public decimal InterestRate => _interestRate;

    public Debt(decimal balance, decimal interestRate)
    {
        if (balance <= 0) throw new ArgumentException("Balance must be greater than zero.");
        if (interestRate < 0) throw new ArgumentException("Interest rate cannot be negative.");

        _balance = balance;
        _interestRate = interestRate;
    }

    // Abstract method for polymorphism, to be implemented by derived classes
    public abstract decimal CalculateMonthlyPayment();

    // Method for making a payment and recording payment history
    public virtual void MakePayment(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Payment must be greater than zero.");
            return;
        }

        if (amount > _balance)
        {
            Console.WriteLine($"Payment exceeds the balance of {Balance:C}. Adjusting to the full balance.");
            amount = _balance;
        }

        _balance -= amount;

        // Record the payment in payment history
        _paymentHistory.Add($"Payment of {amount:C} made on {DateTime.Now}");

        Console.WriteLine($"Payment of {amount:C} applied. Remaining balance: {_balance:C}.");
    }

    // Method to retrieve the payment history
    public List<string> GetPaymentHistory()
    {
        return new List<string>(_paymentHistory); // Return a copy to protect internal list
    }

    // Override ToString for a clear description of the debt
    public override string ToString()
    {
        return $"Balance: {Balance:C}, Interest Rate: {InterestRate:P}";
    }
}
