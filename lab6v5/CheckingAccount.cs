
public class CheckingAccount : BankAccount
{
    public decimal OverdraftLimit { get; set; }

    public CheckingAccount(
        string accountNumber,
        decimal balance,
        decimal overdraftLimit)
        : base(accountNumber, balance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            System.Console.WriteLine(
                "Сума поповнення має бути більшою за нуль.");
            return;
        }

        Balance += amount;

        System.Console.WriteLine(
            $"Поточний рахунок {AccountNumber}: " +
            $"внесено {amount:F2}. Баланс: {Balance:F2}.");
    }

    public void ProcessCheck()
    {
        decimal checkAmount = 100m;

        if (Balance - checkAmount >= -OverdraftLimit)
        {
            Balance -= checkAmount;

            System.Console.WriteLine(
                $"Чек на {checkAmount:F2} оброблено. " +
                $"Баланс: {Balance:F2}.");
        }
        else
        {
            System.Console.WriteLine(
                "Чек відхилено: перевищено ліміт овердрафту.");
        }
    }
}