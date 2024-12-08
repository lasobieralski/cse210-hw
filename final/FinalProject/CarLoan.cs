public class CarLoan : LoanDebt
{
    public string VehicleInfo { get; private set; }
    public decimal VehicleValue { get; private set; }

    public CarLoan(decimal balance, decimal interestRate, int termYears, string vehicleInfo, decimal vehicleValue)
        : base(balance, interestRate, termYears)
    {
        VehicleInfo = vehicleInfo;
        VehicleValue = vehicleValue;
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

        return (Balance * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -totalMonths));
    }

    public override void MakePayment(decimal amount)
    {
        base.MakePayment(amount);
        Console.WriteLine($"Payment of {amount:C} applied to Car Loan for {VehicleInfo}.");
    }

    public override string GenerateDetailedLoanReport()
    {
        string underwaterStatus = Balance > VehicleValue ? "Underwater" : "Not Underwater";
        return $"Car Loan for {VehicleInfo}:\n" +
               $"- Vehicle Value: {VehicleValue:C}\n" +
               $"- {underwaterStatus}\n" +
               $"- Monthly Payment: {CalculateMonthlyPayment():C}";
    }
}
