using System;

namespace lab19v5;

public class OrderNotFoundException : Exception
{
    public int OrderId { get; }

    public OrderNotFoundException(int orderId)
        : base($"Замовлення з ID {orderId} не знайдено.")
    {
        OrderId = orderId;
    }

    public OrderNotFoundException(int orderId, string message)
        : base(message)
    {
        OrderId = orderId;
    }

    public OrderNotFoundException(int orderId, string message, Exception innerException)
        : base(message, innerException)
    {
        OrderId = orderId;
    }
}