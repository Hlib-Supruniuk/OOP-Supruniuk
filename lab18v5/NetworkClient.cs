using System;
using System.Net.Http;

namespace lab18v5;

public class NetworkClient
{
    private int attempts = 0;

    public bool SendConfigUpdate(string url, string configJson)
    {
        attempts++;

        Console.WriteLine($"Спроба надсилання оновлення: {attempts}");

        if (attempts <= 3)
        {
            throw new HttpRequestException(
                "Помилка під час надсилання конфігурації."
            );
        }

        Console.WriteLine("Конфігурацію успішно надіслано!");
        Console.WriteLine($"Адреса: {url}");
        Console.WriteLine($"Дані: {configJson}");

        return true;
    }
}