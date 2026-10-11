
public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; }

    public SavingsAccount(
        string accountNumber,
        decimal balance,
        decimal interestRate)
        : base(accountNumber, balance)
    {
        InterestRate = interestRate;
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
            $"Ощадний рахунок {AccountNumber}: " +
            $"внесено {amount:F2}. Баланс: {Balance:F2}.");
    }

    public void AddInterest()
    {
        decimal interest = Balance * InterestRate / 100;
        Balance += interest;

        System.Console.WriteLine(
            $"Нараховано відсотки: {interest:F2}. " +
            $"Баланс: {Balance:F2}.");
    }

    public new string GetAccountType()
    {
        return "Ощадний рахунок";
    }
}
