public class Lion : Animal
{
    public double ManeSize { get; set; }

    public Lion(string name, double maneSize) : base(name)
    {
        ManeSize = maneSize;
    }

    public override void MakeSound()
    {
        Sound = $"{Name}: Р-Р-Р";
        Console.WriteLine(Sound);
    }
}