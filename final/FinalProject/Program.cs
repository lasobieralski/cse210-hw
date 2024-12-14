using System;
using System.Collections.Generic;
public class Program
{
    static Person currentPerson;
    static Budget budget;
    static List<Debt> debts = new List<Debt>();
    static bool isDemoMode = false;

    // Backup fields for original data before demo mode
    static decimal originalLimit;
    static List<Expense> originalExpenses;
    static List<Debt> originalDebts;
    public static void Main()
    {
        Console.Write("Please enter your full name (e.g., John Doe): ");
        string fullName = Console.ReadLine();
        string[] nameParts = fullName.Split(' ');

        if (nameParts.Length < 2)
        {
            Console.WriteLine("Invalid name format. Please use 'First Last'.");
            return; // Exit the program if invalid name
        }
        // Initialize the Person object
        currentPerson = new Person(nameParts[0], nameParts[1]);
        Console.WriteLine($"\nHello {currentPerson.GetFullName()}!\nWelcome to Your Personalized Budget Program!");
        currentPerson.LoadData(out decimal loadedLimit, out List<Expense> loadedExpenses, out List<Debt> loadedDebts);
        
        if (loadedLimit > 0)
        {
            // Returning user with previously saved data
            budget = new Budget(loadedLimit);
            foreach (var exp in loadedExpenses)
                budget.AddExpense(exp);
                debts = loadedDebts;

            //Console.WriteLine("Loaded existing data from file.");
        }
        else
        {
            // New user or no existing data
            budget = new Budget(0m);
            debts = new List<Debt>();
            Console.WriteLine("No previous data found.");
        }

        // Backup the currently loaded data
        originalLimit = budget.MonthlyLimit;
        originalExpenses = budget.GetExpenses();
        originalDebts = new List<Debt>(debts);

        Console.Write("Would you like to try the Demo Mode before proceeding? (y/n): ");
        string demoChoice = Console.ReadLine().ToLower();
        if (demoChoice == "y")
        {
            EnterDemoMode();
        }
        else
        {
            if (originalLimit == 0)
            {
                Console.WriteLine("Let's get you started by entering your monthly limit. Press Enter.");
                Console.ReadLine();
                SetMonthlyLimit();
            }
        }

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine($"\nWelcome to the Demo Budget Program, {currentPerson.GetFullName()}!");
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Manage Budget Limit");
            Console.WriteLine("2. Manage Expenses");
            Console.WriteLine("3. Manage Debts");
            Console.WriteLine("4. View Budget Report");
            Console.WriteLine("5. Exit Program");

            if (isDemoMode)
            {
                Console.WriteLine("6. Exit Demo Mode");
            }
            
            Console.Write("Select an option: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        SetMonthlyLimit();
                        break;
                    case 2:
                        ManageExpenses();
                        break;
                    case 3:
                        ManageDebts();
                        break;
                    case 4:
                        ViewBudgetReport();
                        break;
                    case 5:
                        if (!isDemoMode)
                        {
                            SaveData();
                        }
                        else
                        {
                            Console.WriteLine("Exiting demo mode. Press Enter.");
                            Console.ReadLine();
                        }
                
                        running = false;
                        break;
                    case 6:

                        if (isDemoMode)
                        {
                            ExitDemoMode();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Press Enter.");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
            }
        }
        Console.WriteLine("Goodbye!");
    }
    static void EnterDemoMode()
    {
        isDemoMode = true;
        budget = new Budget(0);
        debts = new List<Debt>();

        DemoData demo = new DemoData();
        demo.LoadDemo(budget, debts);

        Console.WriteLine("Demo data loaded. Press Enter to continue.");
        Console.ReadLine();
    }
    static void ExitDemoMode()
    {
        // Restore original data
        isDemoMode = false;

        budget = new Budget(originalLimit);
        foreach (var exp in originalExpenses)
            budget.AddExpense(exp);

        debts = new List<Debt>(originalDebts);

        Console.WriteLine("You have exited demo mode. Press Enter to continue.");
        Console.ReadLine();
    }
    static void SetMonthlyLimit()
    {
        Console.Write($"Current Monthly Limit: {budget.MonthlyLimit:C}\nEnter new monthly limit: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal newLimit))
        {
            budget.MonthlyLimit = newLimit;
            // Also update originalLimit if we are not in demo mode
            if (!isDemoMode)
            {
                originalLimit = newLimit;
            }
            Console.WriteLine("Monthly limit updated. Press Enter.");
        }
        else
        {
            Console.WriteLine("Invalid input. Monthly limit not changed. Press Enter.");
        }
        Console.ReadLine();
    }
    static void ManageExpenses()
    {
        bool done = false;
        while (!done)
        {
            Console.Clear();
            Console.WriteLine("Manage Expenses:");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Remove an Expense");
            Console.WriteLine("4. Back");
            Console.Write("Choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1: AddExpense(); break;
                    case 2: ViewExpenses(); break;
                    case 3: RemoveExpense(); break;
                    case 4: done = true; break;
                }
            }
        }
    }
    static void AddExpense()
    {
        Console.Write("Enter expense name: ");
        string name = Console.ReadLine();
        Console.Write("Enter expense amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.Write("Enter expense category: ");
            string category = Console.ReadLine();
            budget.AddExpense(new Expense(name, amount, category));
            // If not in demo mode, update our backups
            if (!isDemoMode)
            {
                originalExpenses = budget.GetExpenses();
            }
            Console.WriteLine("Expense added. Press Enter.");
        }
        else
        {
            Console.WriteLine("Invalid amount. Press Enter.");
        }
        Console.ReadLine();
    }
    static void ViewExpenses()
    {
        Console.Clear();
        var expenses = budget.GetExpenses();
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses recorded.");
        }
        else
        {
            foreach (var e in expenses)
            {
                Console.WriteLine(e);
            }
        }
        Console.WriteLine("Press Enter to return.");
        Console.ReadLine();
    }
    static void RemoveExpense()
    {
        var expenses = budget.GetExpenses();
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses to remove. Press Enter.");
            Console.ReadLine();
            return;
        }

        for (int i = 0; i < expenses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {expenses[i]}");
        }

        Console.Write("Select the expense number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= expenses.Count)
        {
            budget.RemoveExpense(expenses[index - 1]);
            // Update backup if not in demo mode
            if (!isDemoMode)
            {
                originalExpenses = budget.GetExpenses();
            }
            Console.WriteLine("Expense removed. Press Enter.");
        }
        else
        {
            Console.WriteLine("Invalid selection. Press Enter.");
        }
        Console.ReadLine();
    }
    static void ManageDebts()
    {
        bool done = false;
        while (!done)
        {
            Console.Clear();
            Console.WriteLine("Manage Debts:");
            Console.WriteLine("1. Add Debt");
            Console.WriteLine("2. View Debts");
            Console.WriteLine("3. Make a Payment");
            Console.WriteLine("4. Back");
            Console.Write("Select a choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1: AddDebt(); break;
                    case 2: ViewDebts(); break;
                    case 3: MakePayment(); break;
                    case 4: done = true; break;
                }
            }
        }
    }
    static void AddDebt()
    {
        Console.Write("Enter debt type (1 for Credit Card, 2 for Loan): ");
        int debtType = int.Parse(Console.ReadLine());

        Console.Write("Enter the debt name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        Console.Write("Enter the interest rate (e.g., 0.05 for 5%): ");
        decimal interestRate = decimal.Parse(Console.ReadLine());

        if (debtType == 1)
        {
            debts.Add(new CreditCardDebt(name, balance, interestRate));
        }
        else if (debtType == 2)
        {
            Console.Write("Enter the loan term in years: ");
            int termYears = int.Parse(Console.ReadLine());
            debts.Add(new LoanDebt(name, balance, interestRate, termYears));
        }
        else
        {
            Console.WriteLine("Invalid debt type.");
        }

        // Update backup if not in demo mode
        if (!isDemoMode)
        {
            originalDebts = new List<Debt>(debts);
        }

        Console.WriteLine("Debt added. Press Enter.");
        Console.ReadLine();
    }
    static void ViewDebts()
    {
        Console.Clear();
        if (debts.Count == 0)
        {
            Console.WriteLine("No debts to display.");
        }
        else
        {
            foreach (var d in debts)
            {
                Console.WriteLine(d);
            }
        }
        Console.WriteLine("\nPress Enter to return.");
        Console.ReadLine();
    }
    static void MakePayment()
    {
        Console.WriteLine("Select a debt to make a payment:");
        for (int i = 0; i < debts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {debts[i]}");
        }

        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= debts.Count)
        {
            Console.Write("Enter the payment amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal payment))
            {
                debts[choice - 1].MakePayment(payment);
                // Update backup if not in demo mode
                if (!isDemoMode)
                {
                    originalDebts = new List<Debt>(debts);
                }
                Console.WriteLine("Payment made successfully. Press Enter.");
            }
            else
            {
                Console.WriteLine("Invalid payment amount. Press Enter.");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection. Press Enter.");
        }
        Console.ReadLine();
    }
    static void ViewBudgetReport()
    {
        ReportGenerator reportGenerator = new ReportGenerator();
        string fullReport = reportGenerator.GenerateFullReport(budget.GetExpenses(), debts, budget.MonthlyLimit);
        Console.WriteLine(fullReport);
        Console.WriteLine("Press Enter to return.");
        Console.ReadLine();
    }
    static void SaveData()
    {
        if (isDemoMode)
        {
            Console.WriteLine("You are currently in demo mode. Changes are not saved. Press Enter.");
            Console.ReadLine();
        }
        else
        {
            currentPerson.SaveData(budget.MonthlyLimit, budget.GetExpenses(), debts);
            string fileName = currentPerson.GetFileName();
            Console.WriteLine("Data saved successfully.");
            Console.WriteLine($"File saved to: {fileName}");
        }
    }
}