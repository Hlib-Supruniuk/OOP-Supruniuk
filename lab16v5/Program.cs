using System;
using System.Collections.Generic;

namespace lab16v5;

class Program
{
    static void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Іван Петренко", City = "Kyiv" },
            new Customer { Id = 2, Name = "Марія Коваленко", City = "Lviv" },
            new Customer { Id = 3, Name = "Олег Шевченко", City = "Kyiv" },
            new Customer { Id = 4, Name = "Анна Бондаренко", City = "Odesa" },
            new Customer { Id = 5, Name = "Андрій Мельник", City = "Kyiv" },
            new Customer { Id = 6, Name = "Софія Ткаченко", City = "Dnipro" },
            new Customer { Id = 7, Name = "Максим Кравченко", City = "Lviv" },
            new Customer { Id = 8, Name = "Олена Мороз", City = "Kyiv" },
            new Customer { Id = 9, Name = "Дмитро Лисенко", City = "Odesa" },
            new Customer { Id = 10, Name = "Ірина Савченко", City = "Kyiv" }
        };

        List<Order> orders = new List<Order>
        {
            new Order { Id = 1, OrderDate = new DateTime(2026, 1, 10), CustomerId = 1, TotalAmount = 1500 },
            new Order { Id = 2, OrderDate = new DateTime(2026, 1, 12), CustomerId = 2, TotalAmount = 800 },
            new Order { Id = 3, OrderDate = new DateTime(2026, 1, 15), CustomerId = 3, TotalAmount = 2300 },
            new Order { Id = 4, OrderDate = new DateTime(2026, 1, 18), CustomerId = 4, TotalAmount = 450 },
            new Order { Id = 5, OrderDate = new DateTime(2026, 2, 2), CustomerId = 5, TotalAmount = 1200 },
            new Order { Id = 6, OrderDate = new DateTime(2026, 2, 5), CustomerId = 1, TotalAmount = 700 },
            new Order { Id = 7, OrderDate = new DateTime(2026, 2, 8), CustomerId = 6, TotalAmount = 950 },
            new Order { Id = 8, OrderDate = new DateTime(2026, 2, 12), CustomerId = 7, TotalAmount = 1800 },
            new Order { Id = 9, OrderDate = new DateTime(2026, 2, 15), CustomerId = 8, TotalAmount = 3200 },
            new Order { Id = 10, OrderDate = new DateTime(2026, 2, 20), CustomerId = 9, TotalAmount = 600 },
            new Order { Id = 11, OrderDate = new DateTime(2026, 3, 1), CustomerId = 10, TotalAmount = 2700 },
            new Order { Id = 12, OrderDate = new DateTime(2026, 3, 4), CustomerId = 3, TotalAmount = 1100 },
            new Order { Id = 13, OrderDate = new DateTime(2026, 3, 8), CustomerId = 5, TotalAmount = 500 },
            new Order { Id = 14, OrderDate = new DateTime(2026, 3, 12), CustomerId = 2, TotalAmount = 1400 },
            new Order { Id = 15, OrderDate = new DateTime(2026, 3, 16), CustomerId = 8, TotalAmount = 2100 }
        };

        Console.WriteLine($"Кількість клієнтів: {customers.Count}");
        Console.WriteLine($"Кількість замовлень: {orders.Count}");
        Console.WriteLine("\n1. Замовлення клієнтів із Kyiv на суму понад 1000:");

// Query Syntax
var stopwatch = System.Diagnostics.Stopwatch.StartNew();

var querySyntax = (from order in orders
                   join customer in customers
                   on order.CustomerId equals customer.Id
                   where customer.City == "Kyiv" && order.TotalAmount > 1000
                   select new
                   {
                       order.Id,
                       customer.Name,
                       order.TotalAmount
                   }).ToList();

stopwatch.Stop();

Console.WriteLine("\nQuery Syntax:");
foreach (var item in querySyntax)
{
    Console.WriteLine($"Замовлення №{item.Id} | {item.Name} | Сума: {item.TotalAmount}");
}

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

// Method Syntax
stopwatch.Restart();

var methodSyntax = orders
    .Join(customers,
        order => order.CustomerId,
        customer => customer.Id,
        (order, customer) => new { order, customer })
    .Where(x => x.customer.City == "Kyiv" && x.order.TotalAmount > 1000)
    .Select(x => new
    {
        x.order.Id,
        x.customer.Name,
        x.order.TotalAmount
    })
    .ToList();

stopwatch.Stop();

Console.WriteLine("\nMethod Syntax:");
foreach (var item in methodSyntax)
{
    Console.WriteLine($"Замовлення №{item.Id} | {item.Name} | Сума: {item.TotalAmount}");
}

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

Console.WriteLine("\n2. Замовлення та їхні клієнти:");

// Query Syntax
stopwatch.Restart();

var joinQuery = (from order in orders
                 join customer in customers
                 on order.CustomerId equals customer.Id
                 select new
                 {
                     order.Id,
                     order.OrderDate,
                     customer.Name
                 }).ToList();

stopwatch.Stop();

Console.WriteLine("\nQuery Syntax:");

foreach (var item in joinQuery)
{
    Console.WriteLine(
        $"Замовлення №{item.Id} | Дата: {item.OrderDate:dd.MM.yyyy} | Клієнт: {item.Name}");
}

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

// Method Syntax
stopwatch.Restart();

var joinMethod = orders
    .Join(customers,
        order => order.CustomerId,
        customer => customer.Id,
        (order, customer) => new
        {
            order.Id,
            order.OrderDate,
            customer.Name
        })
    .ToList();

stopwatch.Stop();

Console.WriteLine("\nMethod Syntax:");

foreach (var item in joinMethod)
{
    Console.WriteLine(
        $"Замовлення №{item.Id} | Дата: {item.OrderDate:dd.MM.yyyy} | Клієнт: {item.Name}");
}

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

Console.WriteLine("\n3. Загальна сума замовлень для кожного клієнта:");

// Query Syntax
stopwatch.Restart();

var groupQuery = (from order in orders
                  join customer in customers
                  on order.CustomerId equals customer.Id
                  group order by customer.Name into customerOrders
                  select new
                  {
                      CustomerName = customerOrders.Key,
                      Total = customerOrders.Sum(o => o.TotalAmount)
                  }).ToList();

stopwatch.Stop();

Console.WriteLine("\nQuery Syntax:");

foreach (var item in groupQuery)
{
    Console.WriteLine($"{item.CustomerName} | Загальна сума: {item.Total}");
}

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

// Method Syntax
stopwatch.Restart();

var groupMethod = orders
    .Join(customers,
        order => order.CustomerId,
        customer => customer.Id,
        (order, customer) => new { order, customer })
    .GroupBy(x => x.customer.Name)
    .Select(g => new
    {
        CustomerName = g.Key,
        Total = g.Sum(x => x.order.TotalAmount)
    })
    .ToList();

stopwatch.Stop();

Console.WriteLine("\nMethod Syntax:");

foreach (var item in groupMethod)
{
    Console.WriteLine($"{item.CustomerName} | Загальна сума: {item.Total}");
}

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

Console.WriteLine("\n4. Замовлення з максимальною сумою:");

// Query Syntax
stopwatch.Restart();

var maxQuery = (from order in orders
                orderby order.TotalAmount descending
                select order).First();

stopwatch.Stop();

Console.WriteLine("\nQuery Syntax:");
Console.WriteLine(
    $"Замовлення №{maxQuery.Id} | Сума: {maxQuery.TotalAmount}");

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

// Method Syntax
stopwatch.Restart();

var maxMethod = orders
    .OrderByDescending(order => order.TotalAmount)
    .First();

stopwatch.Stop();

Console.WriteLine("\nMethod Syntax:");
Console.WriteLine(
    $"Замовлення №{maxMethod.Id} | Сума: {maxMethod.TotalAmount}");

Console.WriteLine($"Час виконання: {stopwatch.ElapsedTicks} ticks");

Console.WriteLine("\nАНАЛІЗ ПРОДУКТИВНОСТІ:");
Console.WriteLine("Усі чотири LINQ-запити успішно виконані у двох варіантах синтаксису.");
Console.WriteLine("Query Syntax та Method Syntax повертають однакові результати.");
Console.WriteLine("Час виконання залежить від складності запиту, обсягу даних та умов середовища.");
Console.WriteLine("Для невеликих колекцій різниця у швидкодії між двома синтаксисами не є показовою.");
    }
}