public class RemoveShapeCommand : ICommand
{
    private string _shapeName;

    public RemoveShapeCommand(string shapeName)
    {
        _shapeName = shapeName;
    }

    public void Execute()
    {
        Console.WriteLine($"Фігуру «{_shapeName}» видалено.");
    }

    public void Undo()
    {
        Console.WriteLine($"Видалення фігури «{_shapeName}» скасовано.");
    }
}