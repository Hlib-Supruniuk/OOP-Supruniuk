namespace lab17v5;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<City> Cities { get; set; }

    public Country(int id, string name, List<City> cities)
    {
        Id = id;
        Name = name;
        Cities = cities;
    }
}