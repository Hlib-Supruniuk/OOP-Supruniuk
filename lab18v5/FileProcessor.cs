using System;
using System.IO;

namespace lab18v5;

public class FileProcessor
{
    private int attempts = 0;

    public void UpdateConfig(string path, string key, string value)
    {
        attempts++;

        Console.WriteLine($"Спроба оновлення конфігурації: {attempts}");

        if (attempts <= 2)
        {
            throw new IOException("Помилка під час оновлення конфігурації.");
        }

        Console.WriteLine($"Конфігурацію успішно оновлено!");
        Console.WriteLine($"Файл: {path}");
        Console.WriteLine($"Параметр: {key} = {value}");
    }
}