using System;

namespace lab19v5;

class Program
{
    static void Main(string[] args)
    {
        OrderService orderService = new OrderService();

        Console.WriteLine("=== ОТРИМАННЯ ЗАМОВЛЕННЯ ===");

        try
        {
            Order order = orderService.GetOrder(1);

            Console.WriteLine($"Замовлення №{order.Id}");
            Console.WriteLine($"Товар: {order.ProductName}");
            Console.WriteLine($"Кількість: {order.Quantity}");
        }
        catch (OrderNotFoundException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("\n=== ПОШУК НЕІСНУЮЧОГО ЗАМОВЛЕННЯ ===");

        try
        {
            Order order = orderService.GetOrder(10);
        }
        catch (OrderNotFoundException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            Console.WriteLine($"ID замовлення: {ex.OrderId}");
        }

        Console.WriteLine("\n=== УСПІШНЕ ОФОРМЛЕННЯ ===");

        Result<bool> successResult = orderService.PlaceOrder(
            new Order(4, "Мишка", 2)
        );

        if (successResult.IsSuccess)
        {
            Console.WriteLine("Замовлення успішно оформлено!");
        }
        else
        {
            Console.WriteLine($"Помилка: {successResult.Error}");
        }

        Console.WriteLine("\n=== НЕВДАЛЕ ОФОРМЛЕННЯ ===");

        Result<bool> failureResult = orderService.PlaceOrder(
            new Order(5, "Клавіатура", 1)
        );

        if (failureResult.IsSuccess)
        {
            Console.WriteLine("Замовлення успішно оформлено!");
        }
        else
        {
            Console.WriteLine($"Помилка: {failureResult.Error}");
        }
    }
}