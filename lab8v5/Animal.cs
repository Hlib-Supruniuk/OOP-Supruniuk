public class Animal
{
    public string Name { get; set; }
    public string Sound { get; protected set; } = "";

    public Animal(string name)
    {
        Name = name;
    }

    public virtual void MakeSound()
    {
        Sound = $"{Name} видає звук.";
        Console.WriteLine(Sound);
    }
}