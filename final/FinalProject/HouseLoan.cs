public class HouseLoan : LoanDebt
{
    public decimal PropertyTaxDeduction { get; private set; }

    public HouseLoan(decimal balance, decimal interestRate, int termYears, decimal propertyTaxDeduction)
        : base(balance, interestRate, termYears)
    {
        PropertyTaxDeduction = propertyTaxDeduction;
    }

    public override decimal CalculateMonthlyPayment()
    {
        decimal monthlyRate = InterestRate / 12; // Convert annual interest rate to monthly
        int totalMonths = TermYears * 12; // Total number of payments

        // Use amortization formula
        if (monthlyRate == 0) // Handle zero-interest loans
        {
            return Balance / totalMonths;
        }

        decimal basePayment = (Balance * monthlyRate) / 
                              (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -totalMonths));

        // Reduce payment by property tax deduction (if applicable)
        return basePayment - (PropertyTaxDeduction / totalMonths);
    }

    public override string GenerateDetailedLoanReport()
    {
        return $"House Loan:\n" +
               $"- Balance: {Balance:C}\n" +
               $"- Interest Rate: {InterestRate:P}\n" +
               $"- Property Tax Deduction: {PropertyTaxDeduction:C}\n" +
               $"- Monthly Payment: {CalculateMonthlyPayment():C}";
    }

    public override void MakePayment(decimal amount)
    {
        base.MakePayment(amount);
        Console.WriteLine($"Payment of {amount:C} applied to House Loan. Remaining Balance: {Balance:C}");
    }
}
