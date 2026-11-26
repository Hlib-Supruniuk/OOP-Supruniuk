namespace lab17v5;

public class Landmark
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Landmark(int id, string name)
    {
        Id = id;
        Name = name;
    }
}