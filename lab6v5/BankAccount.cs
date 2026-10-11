
public class BankAccount
{
    private string _accountNumber;
    private decimal _balance;

    public string AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value;
    }

    public decimal Balance
    {
        get => _balance;
        protected set => _balance = value;
    }

    public BankAccount(string accountNumber, decimal balance)
    {
        _accountNumber = accountNumber;
        _balance = balance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            System.Console.WriteLine("Сума поповнення має бути більшою за нуль.");
            return;
        }

        Balance += amount;
        System.Console.WriteLine(
            $"Рахунок {_accountNumber}: внесено {amount:F2}. Баланс: {Balance:F2}.");
    }

    public string GetAccountType()
    {
        return "Звичайний банківський рахунок";
    }
}
