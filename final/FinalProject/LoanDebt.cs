public abstract class LoanDebt : Debt
{
    protected int TermYears;

    public LoanDebt(decimal balance, decimal interestRate, int termYears)
        : base(balance, interestRate)
    {
        TermYears = termYears;
    }

    public override decimal CalculateMonthlyPayment()
    {
        decimal monthlyRate = InterestRate / 12;
        int totalMonths = TermYears * 12;
        return (Balance * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -totalMonths));
    }


    public abstract string GenerateDetailedLoanReport(); // Abstract method for detailed reports
}

