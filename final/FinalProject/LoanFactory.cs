public static class LoanFactory
{
    public static LoanDebt CreateCarLoan(decimal balance, decimal interestRate, int termYears, string vehicleInfo, decimal vehicleValue)
    {
        return new CarLoan(balance, interestRate, termYears, vehicleInfo, vehicleValue);
    }

    public static LoanDebt CreateHouseLoan(decimal balance, decimal interestRate, int termYears, decimal taxDeduction)
    {
        return new HouseLoan(balance, interestRate, termYears, taxDeduction);
    }
}
