namespace lab17v5;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Population { get; set; }
    public List<Landmark> Landmarks { get; set; }

    public City(int id, string name, int population, List<Landmark> landmarks)
    {
        Id = id;
        Name = name;
        Population = population;
        Landmarks = landmarks;
    }
}