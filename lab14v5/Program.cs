using System;
using System.Collections.Generic;

Console.WriteLine("=== ГРУПУВАННЯ ТОВАРІВ ЗА КАТЕГОРІЯМИ ===");

List<Product> products = new List<Product>
{
    new Product("Ноутбук", "Електроніка", 25000),
    new Product("Телефон", "Електроніка", 18000),
    new Product("Стіл", "Меблі", 5000),
    new Product("Стілець", "Меблі", 2500),
    new Product("Навушники", "Електроніка", 1500)
};

var productGroups = CollectionHelper<Product>.GroupBy(
    products,
    product => product.Category
);

foreach (var group in productGroups)
{
    Console.WriteLine($"\nКатегорія: {group.Key}");

    foreach (Product product in group.Value)
    {
        Console.WriteLine($"- {product.Name}, ціна: {product.Price} грн");
    }
}

Console.WriteLine("\n=== ГРУПУВАННЯ СТУДЕНТІВ ЗА КУРСАМИ ===");

List<Student> students = new List<Student>
{
    new Student("Андрій", 1),
    new Student("Марія", 2),
    new Student("Олег", 1),
    new Student("Ірина", 3),
    new Student("Дмитро", 2)
};

var studentGroups = CollectionHelper<Student>.GroupBy(
    students,
    student => student.Course
);

foreach (var group in studentGroups)
{
    Console.WriteLine($"\nКурс: {group.Key}");

    foreach (Student student in group.Value)
    {
        Console.WriteLine($"- {student.Name}");
    }
}