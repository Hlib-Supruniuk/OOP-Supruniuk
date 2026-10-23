public class ConsoleShapeDrawer : ShapeDrawer
{
    public override void DrawShape(string shapeType)
    {
        Console.WriteLine(
            $"Малювання фігури «{shapeType}» у консолі. Колір: {Color}");
    }
}