public class SvgShapeDrawer : ShapeDrawer
{
    public override void DrawShape(string shapeType)
    {
        Console.WriteLine(
            $"Створення SVG-фігури «{shapeType}». Колір: {Color}");
    }
}