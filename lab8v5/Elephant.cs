public class Elephant : Animal
{
    public double TrunkLength { get; set; }

    public Elephant(string name, double trunkLength) : base(name)
    {
        TrunkLength = trunkLength;
    }

    public override void MakeSound()
    {
        Sound = $"{Name}: У-У-У";
        Console.WriteLine(Sound);
    }
}