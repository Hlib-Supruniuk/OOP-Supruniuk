using System.Collections.Generic;
using System.Linq;

namespace lab17v5;

public static class CityExtensions
{
    public static int TotalPopulation(this IEnumerable<City> cities)
    {
        return cities.Sum(city => city.Population);
    }
}