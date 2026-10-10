
using System;

Console.WriteLine("=== Створення об'єктів ===");

// Об'єкт 1: конструктор за замовчуванням
City city1 = new City();

// Об'єкт 2: параметризований конструктор
City city2 = new City("Kyiv", "Ukraine", 2950000);

// Об'єкт 3: параметризований конструктор
City city3 = new City("Lviv", "Ukraine", 717000);

Console.WriteLine(city1.GetCityInfo());
Console.WriteLine(city2.GetCityInfo());
Console.WriteLine(city3.GetCityInfo());

Console.WriteLine("\n=== Перевірка валідації ===");

try
{
    city2.Population = -100;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}

Console.WriteLine("\n=== Завершення програми ===");

// Демонстрація роботи фіналізаторів.
Console.WriteLine("\n=== Перевірка фіналізаторів ===");

city1 = null!;
city2 = null!;
city3 = null!;


CreateTemporaryCity();
GC.Collect();
GC.WaitForPendingFinalizers();

Console.WriteLine("Демонстрацію завершено.");

static void CreateTemporaryCity()
{
    City temporaryCity = new City(
        "Odesa",
        "Ukraine",
        1010000
    );

    Console.WriteLine(temporaryCity.GetCityInfo());
}