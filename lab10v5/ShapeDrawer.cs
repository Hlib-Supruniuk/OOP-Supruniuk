public abstract class ShapeDrawer
{
    protected string Color { get; private set; } = "Чорний";

    public abstract void DrawShape(string shapeType);

    public void SetColor(string color)
    {
        Color = color;
        Console.WriteLine($"Колір фігури встановлено: {Color}");
    }
}