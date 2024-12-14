using System;
using System.Collections.Generic;
using System.IO;
public class Person
{
    private string firstName;
    private string lastName;
    public Person(string firstName, string lastName)
    {
        this.firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
        this.lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
    }
    public string GetFullName()
    {
        return $"{firstName} {lastName}";
    }
    public string GetFileName()
    {
        return $"{firstName.ToLower()}.{lastName.ToLower()}_budget.txt";
    }
    public void SaveData(decimal monthlyLimit, List<Expense> expenses, List<Debt> debts)
    {
        string fileName = GetFileName();
        using (var writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Person: {GetFullName()}");
            writer.WriteLine($"MonthlyLimit: {monthlyLimit}");

            writer.WriteLine("Expenses:");
            foreach (var exp in expenses)
            {
                writer.WriteLine($"Expense:{exp.Name}|{exp.Amount}|{exp.Category}");
            }

            writer.WriteLine("Debts:");
            foreach (var d in debts)
            {
                if (d is CreditCardDebt ccd)
                {
                    writer.WriteLine($"Debt:CreditCard|{ccd.Name}|{ccd.Balance}|{ccd.InterestRate}");
                }
                else if (d is LoanDebt ld)
                {
                    writer.WriteLine($"Debt:Loan|{ld.Name}|{ld.Balance}|{ld.InterestRate}|{ld.TermYears}");
                }
            }
        }
    }
    public void LoadData(out decimal loadedMonthlyLimit, out List<Expense> expenses, out List<Debt> debts)
    {
        loadedMonthlyLimit = 0m;
        expenses = new List<Expense>();
        debts = new List<Debt>();

        string fileName = GetFileName();
        if (!File.Exists(fileName))
        {
            //Console.WriteLine($"No save file found for {GetFullName()}. Starting fresh.");
            return;
        }
        try
        {
            using (var reader = new StreamReader(fileName))
            {
                string personLine = reader.ReadLine(); // Person line
                string limitLine = reader.ReadLine();  // MonthlyLimit line
                if (limitLine != null && limitLine.StartsWith("MonthlyLimit: "))
                {
                    string limitStr = limitLine.Substring("MonthlyLimit: ".Length);
                    decimal.TryParse(limitStr, out loadedMonthlyLimit);
                }

                string line;
                bool readingExpenses = false;
                bool readingDebts = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "Expenses:")
                    {
                        readingExpenses = true;
                        readingDebts = false;
                        continue;
                    }
                    if (line == "Debts:")
                    {
                        readingDebts = true;
                        readingExpenses = false;
                        continue;
                    }
                    if (readingExpenses && line.StartsWith("Expense:"))
                    {
                        string data = line.Substring("Expense:".Length);
                        string[] parts = data.Split('|');
                        if (parts.Length == 3)
                        {
                            string name = parts[0];
                            decimal amount;
                            decimal.TryParse(parts[1], out amount);
                            string category = parts[2];
                            expenses.Add(new Expense(name, amount, category));
                        }
                    }
                    else if (readingDebts && line.StartsWith("Debt:"))
                    {
                        string data = line.Substring("Debt:".Length);
                        string[] dParts = data.Split('|');
                        if (dParts[0] == "CreditCard" && dParts.Length == 4)
                        {
                            string name = dParts[1];
                            decimal balance;
                            decimal.TryParse(dParts[2], out balance);
                            decimal rate;
                            decimal.TryParse(dParts[3], out rate);
                            debts.Add(new CreditCardDebt(name, balance, rate));
                        }
                        else if (dParts[0] == "Loan" && dParts.Length == 5)
                        {
                            string name = dParts[1];
                            decimal balance;
                            decimal.TryParse(dParts[2], out balance);
                            decimal rate;
                            decimal.TryParse(dParts[3], out rate);
                            int term;
                            int.TryParse(dParts[4], out term);
                            debts.Add(new LoanDebt(name, balance, rate, term));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }
}