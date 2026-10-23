using System;
using System.Collections.Generic;

Console.WriteLine("=== Робота з командами ===");

List<ICommand> commands = new List<ICommand>
{
    new AddShapeCommand("Коло"),
    new RemoveShapeCommand("Квадрат")
};

foreach (ICommand command in commands)
{
    command.Execute();
    command.Undo();
}

Console.WriteLine();
Console.WriteLine("=== Малювання фігур ===");

List<ShapeDrawer> drawers = new List<ShapeDrawer>
{
    new ConsoleShapeDrawer(),
    new SvgShapeDrawer()
};

drawers[0].SetColor("Червоний");
drawers[1].SetColor("Синій");

foreach (ShapeDrawer drawer in drawers)
{
    drawer.DrawShape("Коло");
}