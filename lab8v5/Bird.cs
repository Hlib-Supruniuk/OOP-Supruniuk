public class Bird : Animal
{
    public double WingSpan { get; set; }

    public Bird(string name, double wingSpan) : base(name)
    {
        WingSpan = wingSpan;
    }

    public override void MakeSound()
    {
        Sound = $"{Name}: Цвіріньк-Цвіріньк";
        Console.WriteLine(Sound);
    }
}