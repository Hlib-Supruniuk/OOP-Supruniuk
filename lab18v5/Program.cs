using System;
using System.IO;
using System.Net.Http;

namespace lab18v5;

class Program
{
    static void Main(string[] args)
    {
        FileProcessor fileProcessor = new FileProcessor();
        NetworkClient networkClient = new NetworkClient();

        Console.WriteLine("=== ОНОВЛЕННЯ КОНФІГУРАЦІЇ ===");

        RetryHelper.ExecuteWithRetry(
            () =>
            {
                fileProcessor.UpdateConfig(
                    "config.json",
                    "Theme",
                    "Dark"
                );

                return true;
            },
            retryCount: 3,
            initialDelay: TimeSpan.FromSeconds(1),
            shouldRetry: ex => ex is IOException
        );

        Console.WriteLine("\n=== НАДСИЛАННЯ КОНФІГУРАЦІЇ ===");

        bool result = RetryHelper.ExecuteWithRetry(
            () => networkClient.SendConfigUpdate(
                "https://example.com/config",
                "{\"Theme\":\"Dark\"}"
            ),
            retryCount: 4,
            initialDelay: TimeSpan.FromSeconds(1),
            shouldRetry: ex => ex is HttpRequestException
        );

        Console.WriteLine($"\nРезультат надсилання: {result}");
    }
}