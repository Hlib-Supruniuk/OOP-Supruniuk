
using System;

class City
{
    private string _name = "Unknown";
    private string _country = "Unknown";
    private long _population;

    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrWhiteSpace(value)
            ? "Unknown"
            : value;
    }

    public string Country
    {
        get => _country;
        set => _country = string.IsNullOrWhiteSpace(value)
            ? "Unknown"
            : value;
    }

    public long Population
    {
        get => _population;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Населення не може бути від'ємним.");

            _population = value;
        }
    }

    // Конструктор за замовчуванням
    public City() : this("Unknown", "Unknown", 0)
    {
    }

    // Параметризований конструктор
    public City(string name, string country, long population)
    {
        Name = name;
        Country = country;
        Population = population;
    }

    public string GetCityInfo()
    {
        return $"Місто: {Name}, Країна: {Country}, " +
               $"Населення: {Population} осіб";
    }

    // Фіналізатор
    ~City()
    {
        Console.WriteLine($"Фіналізатор: об'єкт міста {Name} знищується.");
    }
}
