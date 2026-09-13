class City
{
    private string name;
    private string country;

    public int Population { get; set; }

    public City(string name, string country, int population)
    {
        this.name = name;
        this.country = country;
        Population = population;
    }

    public string GetInfo()
    {
        return $"Місто: {name}, Країна: {country}, Населення: {Population} осіб";
    }
}