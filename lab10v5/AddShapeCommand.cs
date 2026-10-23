public class AddShapeCommand : ICommand
{
    private string _shapeName;

    public AddShapeCommand(string shapeName)
    {
        _shapeName = shapeName;
    }

    public void Execute()
    {
        Console.WriteLine($"Фігуру «{_shapeName}» додано.");
    }

    public void Undo()
    {
        Console.WriteLine($"Додавання фігури «{_shapeName}» скасовано.");
    }
}