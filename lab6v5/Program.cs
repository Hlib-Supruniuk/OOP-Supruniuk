
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== 1. Створення банківських рахунків ===");

        BankAccount account = new BankAccount("BA-001", 1000m);
        SavingsAccount savings = new SavingsAccount("SA-002", 2000m, 5m);
        CheckingAccount checking = new CheckingAccount("CA-003", 500m, 300m);

        Console.WriteLine($"Звичайний рахунок: {account.AccountNumber}, баланс: {account.Balance:F2}");
        Console.WriteLine($"Ощадний рахунок: {savings.AccountNumber}, баланс: {savings.Balance:F2}");
        Console.WriteLine($"Поточний рахунок: {checking.AccountNumber}, баланс: {checking.Balance:F2}");

        Console.WriteLine("\n=== 2. Поліморфізм: override ===");

        BankAccount[] accounts = { account, savings, checking };

        foreach (BankAccount item in accounts)
        {
            item.Deposit(100m);
        }

        Console.WriteLine("\n=== 3. Унікальні методи похідних класів ===");

        savings.AddInterest();
        checking.ProcessCheck();

        Console.WriteLine("\n=== 4. Різниця між override та new ===");

        BankAccount baseReference = savings;
        SavingsAccount savingsReference = savings;

        Console.WriteLine($"Через BankAccount: {baseReference.GetAccountType()}");
        Console.WriteLine($"Через SavingsAccount: {savingsReference.GetAccountType()}");

        Console.WriteLine("\nДемонстрацію завершено.");
    }
}
