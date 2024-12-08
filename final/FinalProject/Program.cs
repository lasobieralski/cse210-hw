using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Program
{
    static Person currentPerson;
    static Budget budget;
    static List<Debt> debts = new List<Debt>();
    
    public static void Main(string[] args)
    {
        
        Debt creditCard = new CreditCardDebt("Visa Platinum", 1000m, 0.18m);

        Console.WriteLine(creditCard); // Display details

        Console.WriteLine("\nAttempting to make a payment of $20...");
        creditCard.MakePayment(20m); // Below minimum payment

        Console.WriteLine("\nAttempting to make a payment of $50...");
        creditCard.MakePayment(50m); // Valid payment

        Console.WriteLine("\nUpdated Credit Card Details:");
        Console.WriteLine(creditCard);
    
        // Prompt for user information at the start
        Console.Write("Please enter your full name (e.g., John Doe): ");
        string fullName = Console.ReadLine();
        string[] nameParts = fullName.Split(' ');

        if (nameParts.Length < 2)
        {
            Console.WriteLine("Invalid name format. Please use 'First Last'.");
            return;
        }

        // Initialize the Person object
        currentPerson = new Person(nameParts[0], nameParts[1]);
        Console.WriteLine($"\nWelcome to Design Your Budget Program, {currentPerson.GetFullName()}!");

        // Option to load demo data
        Console.WriteLine("\nWould you like to load demo data? (y/n): ");
        string loadDemo = Console.ReadLine();

        if (loadDemo.ToLower() == "y")
        {
            LoadTestData();
        }

        // Main menu loop
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Manage Budget");
            Console.WriteLine("2. Manage Transactions (Expenses/Income)");
            Console.WriteLine("3. Manage Debts (Loans/Credit Cards)");
            Console.WriteLine("4. Reports and Data");
            Console.WriteLine("5. Exit Program");
            Console.WriteLine("6. Help");
            Console.Write("Select a choice (1-6): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ManageBudget();
                        break;
                    case 2:
                        ManageTransactions();
                        break;
                    case 3:
                        ManageDebts();
                        break;
                    case 4:
                        ViewReports();
                        break;
                    case 5:
                        running = false;
                        Console.WriteLine("\nThank you for using the program. Goodbye!");
                        break;
                    case 6:
                        ShowHelp();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void LoadTestData()
    {
        budget = new Budget(3000m);

        // Add some expenses
        budget.AddExpense(new Expense("Groceries", 250m, "Food"));
        budget.AddExpense(new Expense("Electric Bill", 115m, "Utilities"));
        budget.AddExpense(new Expense("Cell Phone Bill", 35m, "Utilities"));
        budget.AddExpense(new Expense("Internet Bill", 50m, "Utilities"));
        budget.AddExpense(new Expense("Rent", 1495m, "Housing"));

        // Add some debts
        debts.Add(new CreditCardDebt("Visa Platinum", 6500m, 0.18m));
        debts.Add(new CreditCardDebt("Shell Visa", 800m, 0.21m));
        
        debts.Add(new CarLoan(20000m, 0.05m, 5, "2022 Toyota Camry", 18000m));
        debts.Add(new HouseLoan(300000m, 0.04m, 30, 10000m));

        Console.WriteLine("Demo data loaded successfully. Press Enter to continue.");
        Console.ReadLine();
    }

    static void ManageBudget()
    {
        bool backToMain = false;
        while (!backToMain)
        {
            Console.Clear();
            Console.WriteLine("\nManage Budget:");
            Console.WriteLine("1. Set Monthly Limit");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View Budget Report");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Select a choice (1-4): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        SetMonthlyLimit();
                        break;
                    case 2:
                        AddExpense();
                        break;
                    case 3:
                        ViewBudgetReport();
                        break;
                    case 4:
                        backToMain = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
    static decimal GetValidDecimal(string prompt)
    {
        decimal value;
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }

    static int GetMenuChoice(string prompt, int min, int max)
    {
        int choice;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine($"Invalid choice. Please select a number between {min} and {max}.");
        }
    }

    static void SetMonthlyLimit()
    {
        Console.Write("Enter the new monthly limit: ");
        decimal newLimit;
        if (decimal.TryParse(Console.ReadLine(), out newLimit) && newLimit > 0)
        {
            if (budget == null)
            {
                budget = new Budget(newLimit);
            }
            else
            {
                budget.SetMonthlyLimit(newLimit);
            }
            Console.WriteLine($"Monthly limit set to: {newLimit:C}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }

    static void AddExpense()
{
    if (budget == null)
    {
        Console.WriteLine("Please set a monthly limit before adding expenses.");
        return;
    }

    // Prompt for expense name
    Console.Write("Enter the expense name: ");
    string name = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(name))
    {
        Console.Write("Expense name cannot be empty. Please enter the expense name: ");
        name = Console.ReadLine();
    }

    // Prompt for expense amount
    decimal amount = GetValidDecimal("Enter the expense amount: ");

    // Prompt for expense category
    Console.Write("Enter the expense category: ");
    string category = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(category))
    {
        Console.Write("Expense category cannot be empty. Please enter the expense category: ");
        category = Console.ReadLine();
    }

    // Create a new Expense object
    Expense expense = new Expense(name, amount, category);

    // Add the expense to the budget
    budget.AddExpense(expense);
    Console.WriteLine($"Expense '{name}' added successfully.");
}


    static void ViewBudgetReport()
    {
        if (budget == null)
        {
            Console.WriteLine("Please set a monthly limit before viewing the report.");
            return;
        }

        Console.WriteLine(budget.GenerateBudgetReport());
        Console.WriteLine("\nPress Enter to return.");
        Console.ReadLine();
    }

    static void ShowHelp()
    {
        Console.Clear();
        Console.WriteLine("Program Help:");
        Console.WriteLine("1. Manage Budget: Set a monthly limit and add expenses.");
        Console.WriteLine("2. Manage Transactions: Add or view expenses.");
        Console.WriteLine("3. Manage Debts: Add debts, view debts, and make payments.");
        Console.WriteLine("4. Reports and Data: View budget and debt summaries.");
        Console.WriteLine("5. Exit Program: Close the program.");
        Console.WriteLine("6. Help: Display this guide.");
        Console.WriteLine("\nPress Enter to return to the main menu.");
        Console.ReadLine();
    }
    static void ManageTransactions()
    {
        bool backToMain = false;
        while (!backToMain)
        {
            Console.Clear();
            Console.WriteLine("\nManage Transactions:");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Select a choice (1-3): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddExpense();
                        break;
                    case 2:
                        ViewExpenses();
                        break;
                    case 3:
                        backToMain = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
    static void ViewExpenses()
    {
        Console.Clear();
        if (budget == null || budget.GetTotalExpenses() == 0)
        {
            Console.WriteLine("No expenses to display.");
        }
        else
        {
            Console.WriteLine(budget.GenerateBudgetReport());
        }
        Console.WriteLine("\nPress Enter to return.");
        Console.ReadLine();
    }
    static void ManageDebts()
    {
        bool backToMain = false;
        while (!backToMain)
        {
            Console.Clear();
        Console.WriteLine("\nManage Debts:");
        Console.WriteLine("1. Add Debt");
        Console.WriteLine("2. View Debts");
        Console.WriteLine("3. Make a Payment");
        Console.WriteLine("4. View Payment History");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Select a choice (1-5): ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    AddDebt();
                    break;
                case 2:
                    ViewDebts();
                    break;
                case 3:
                    MakePayment();
                    break;
                case 4:
                    ViewPaymentHistory();
                    break;
                case 5:
                    backToMain = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}


    static void AddDebt()
    {
        Console.Write("Enter the debt type (1 for Loan, 2 for Credit Card): ");
        int debtType = int.Parse(Console.ReadLine());

        Console.Write("Enter the debt name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        Console.Write("Enter the interest rate (e.g., 0.05 for 5%): ");
        decimal interestRate = decimal.Parse(Console.ReadLine());

        if (debtType == 1)
        {
            Console.Write("Enter the loan term in years: ");
            int termYears = int.Parse(Console.ReadLine());
            
        }
        else if (debtType == 2)
        {
            debts.Add(new CreditCardDebt(name, balance, interestRate));
        }
        else
        {
            Console.WriteLine("Invalid debt type.");
        }
    }

    static void ViewDebts()
    {
        if (debts.Count == 0)
        {
            Console.WriteLine("No debts to display.");
        }
        else
        {
            foreach (var debt in debts)
            {
                Console.WriteLine(debt);
                if (debt is CreditCardDebt creditCardDebt)
                {
                    Console.WriteLine($"Minimum Payment: {creditCardDebt.CalculateMonthlyPayment():C}");
                }
            }
        }
        Console.WriteLine("\nPress Enter to return.");
        Console.ReadLine();
    }

    static void MakePayment()
    {
         if (debts.Count == 0)
        {
            Console.WriteLine("No debts available to make payments.");
            return;
        }

        Console.WriteLine("Select a debt to make a payment:");
        for (int i = 0; i < debts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {debts[i]}");
        }

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > debts.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.Write("Enter the payment amount: ");
        decimal payment;
        if (!decimal.TryParse(Console.ReadLine(), out payment) || payment <= 0)
        {
            Console.WriteLine("Invalid payment amount.");
            return;
        }

        debts[choice - 1].MakePayment(payment);
    } 

    static void ViewPaymentHistory()
    {
        if (debts.Count == 0)
        {
            Console.WriteLine("No debts available to view payment history.");
            return;
        }

        Console.WriteLine("Select a debt to view payment history:");
        for (int i = 0; i < debts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {debts[i]}");
        }

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > debts.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.WriteLine($"Payment History for {debts[choice - 1]}:\n");
        Console.WriteLine(debts[choice - 1].GetPaymentHistory());
        Console.WriteLine("\nPress Enter to return.");
        Console.ReadLine();
    }

    static void ViewReports()
    {
        ReportGenerator reportGenerator = new ReportGenerator();

        Console.Clear();
        Console.WriteLine("\nReports:");
        Console.WriteLine("1. Expense Report");
        Console.WriteLine("2. Debt Report");
        Console.WriteLine("3. Back to Main Menu");
        Console.Write("Select a choice (1-3): ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    if (budget != null)
                    {
                        Console.WriteLine(reportGenerator.GenerateExpenseReport(budget.GetExpenses()));
                    }
                    
                    break;
                case 2:
                    Console.WriteLine(reportGenerator.GenerateDebtReport(debts));
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        Console.WriteLine("\nPress Enter to return.");
        Console.ReadLine();
        
    }
}
