using System;
using System.Threading;

namespace lab18v5;

public static class RetryHelper
{
    public static T ExecuteWithRetry<T>(
        Func<T> operation,
        int retryCount = 3,
        TimeSpan initialDelay = default,
        Func<Exception, bool> shouldRetry = null)
    {
        int attempt = 0;

        while (true)
        {
            try
            {
                attempt++;
                Console.WriteLine($"\nСпроба №{attempt}");

                return operation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");

                if (attempt > retryCount ||
                    (shouldRetry != null && !shouldRetry(ex)))
                {
                    Console.WriteLine("Повторні спроби припинено.");
                    throw;
                }

                TimeSpan delay = TimeSpan.FromMilliseconds(
                    initialDelay.TotalMilliseconds * Math.Pow(2, attempt - 1)
                );

                Console.WriteLine($"Повтор через {delay.TotalSeconds} сек.");

                Thread.Sleep(delay);
            }
        }
    }
}