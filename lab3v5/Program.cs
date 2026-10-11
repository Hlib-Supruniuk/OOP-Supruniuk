using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Сценарій 1: Використанння using ===");

        using (GraphicsContext context = new GraphicsContext(1))
        {
            context.DrawShape("Коло");
        }

        Console.WriteLine();

        Console.WriteLine("=== Сценарій 2: явний виклик Dispose ===");

        GraphicsContext context2 = new GraphicsContext(2);
        context2.DrawShape("Квадрат");
        context2.Dispose();

        Console.WriteLine();

        Console.WriteLine("=== Сценарій 3: звільнення через фіналізатор ===");

        CreateTemporaryContext();

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine();
        Console.WriteLine("Демонстрацію завершено.");
    }

    static void CreateTemporaryContext()
    {
        GraphicsContext context3 = new GraphicsContext(3);
        context3.DrawShape("Трикутник");
    }
}