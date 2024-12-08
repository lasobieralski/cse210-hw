public class CreditCardDebt : Debt
{
    public string CardName { get; private set; }
    private const decimal MinimumPaymentPercentage = 0.03m; // 3% of balance
    private const decimal MinimumPaymentAmount = 25.00m; // Fixed minimum payment

    public CreditCardDebt(string cardName, decimal balance, decimal interestRate)
        : base(balance, interestRate)
    {
        CardName = cardName;
    }
    public override decimal CalculateMonthlyPayment()
    {
        decimal calculatedPayment = Balance * MinimumPaymentPercentage; // Use public Balance property
        return Math.Max(calculatedPayment, MinimumPaymentAmount);
    }

    public override string ToString()
    {
        return $"{CardName} - Balance: {Balance:C}, Interest Rate: {InterestRate:P}, Minimum Payment: {CalculateMonthlyPayment():C}";
    }

    public override void MakePayment(decimal amount)
    {
        decimal minimumPayment = CalculateMonthlyPayment();

        if (amount < minimumPayment)
        {
            Console.WriteLine($"Payment must be at least the minimum payment of {minimumPayment:C}.");
            return;
        }

        base.MakePayment(amount);
    }
}
