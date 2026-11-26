using System;
using System.Collections.Generic;
using System.Linq;

namespace lab17v5;

class Program
{
    static void Main(string[] args)
    {
        List<Country> countries = new List<Country>
        {
            new Country(1, "Україна", new List<City>
            {
                new City(1, "Київ", 2960000, new List<Landmark>
                {
                    new Landmark(1, "Софійський собор"),
                    new Landmark(2, "Києво-Печерська лавра")
                }),
                new City(2, "Львів", 717000, new List<Landmark>
                {
                    new Landmark(3, "Площа Ринок"),
                    new Landmark(4, "Високий замок")
                }),
                new City(3, "Одеса", 1010000, new List<Landmark>
                {
                    new Landmark(5, "Потьомкінські сходи"),
                    new Landmark(6, "Одеський оперний театр")
                }),
                new City(4, "Харків", 1420000, new List<Landmark>
                {
                    new Landmark(7, "Площа Свободи"),
                    new Landmark(8, "Держпром")
                })
            }),

            new Country(2, "Франція", new List<City>
            {
                new City(5, "Париж", 2100000, new List<Landmark>
                {
                    new Landmark(9, "Ейфелева вежа"),
                    new Landmark(10, "Лувр")
                }),
                new City(6, "Ліон", 522000, new List<Landmark>
                {
                    new Landmark(11, "Базиліка Нотр-Дам-де-Фурв'єр"),
                    new Landmark(12, "Площа Белькур")
                }),
                new City(7, "Марсель", 870000, new List<Landmark>
                {
                    new Landmark(13, "Старий порт"),
                    new Landmark(14, "Базиліка Нотр-Дам-де-ла-Гард")
                }),
                new City(8, "Ніцца", 348000, new List<Landmark>
                {
                    new Landmark(15, "Англійська набережна"),
                    new Landmark(16, "Замкова гора")
                })
            }),

            new Country(3, "Італія", new List<City>
            {
                new City(9, "Рим", 2870000, new List<Landmark>
                {
                    new Landmark(17, "Колізей"),
                    new Landmark(18, "Пантеон")
                }),
                new City(10, "Мілан", 1370000, new List<Landmark>
                {
                    new Landmark(19, "Міланський собор"),
                    new Landmark(20, "Галерея Віктора Еммануїла II")
                }),
                new City(11, "Венеція", 250000, new List<Landmark>
                {
                    new Landmark(21, "Площа Сан-Марко"),
                    new Landmark(22, "Міст Ріальто")
                }),
                new City(12, "Флоренція", 382000, new List<Landmark>
                {
                    new Landmark(23, "Собор Санта-Марія-дель-Фйоре"),
                    new Landmark(24, "Понте-Веккьо")
                })
            })
        };

        var allLandmarks = countries
            .SelectMany(country => country.Cities)
            .SelectMany(city => city.Landmarks)
            .ToList();

        Console.WriteLine("=== УСІ ПАМ'ЯТКИ ===");

        foreach (var landmark in allLandmarks)
        {
            Console.WriteLine(landmark.Name);
        }

        Console.WriteLine($"Загальна кількість пам'яток: {allLandmarks.Count}");

        var allCities = countries
            .SelectMany(country => country.Cities)
            .ToList();

        int pageSize = 4;
        int totalPages = (int)Math.Ceiling(allCities.Count / (double)pageSize);

        for (int page = 0; page < totalPages; page++)
        {
            var citiesOnPage = allCities
                .Skip(page * pageSize)
                .Take(pageSize);

            Console.WriteLine($"\n=== СТОРІНКА {page + 1} ===");

            foreach (var city in citiesOnPage)
            {
                Console.WriteLine($"{city.Name} — населення: {city.Population}");
            }
        }

        int totalPopulation = allCities.TotalPopulation();

        Console.WriteLine("\n=== ЗАГАЛЬНЕ НАСЕЛЕННЯ МІСТ ===");
        Console.WriteLine($"Загальна кількість населення: {totalPopulation:N0}");
    }
}