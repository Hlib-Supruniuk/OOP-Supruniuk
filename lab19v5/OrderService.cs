using System.Collections.Generic;
using System.Linq;

namespace lab19v5;

public class OrderService
{
    private List<Order> orders = new List<Order>
    {
        new Order(1, "Ноутбук", 1),
        new Order(2, "Мишка", 2),
        new Order(3, "Клавіатура", 1)
    };

    private Dictionary<string, int> stock = new Dictionary<string, int>
    {
        { "Ноутбук", 5 },
        { "Мишка", 10 },
        { "Клавіатура", 0 }
    };

    public Order GetOrder(int orderId)
    {
        Order order = orders.FirstOrDefault(o => o.Id == orderId);

        if (order == null)
        {
            throw new OrderNotFoundException(orderId);
        }

        return order;
    }

    public Result<bool> PlaceOrder(Order order)
    {
        if (!stock.ContainsKey(order.ProductName))
        {
            return Result<bool>.Failure("Товар не знайдено.");
        }

        if (order.Quantity <= 0)
        {
            return Result<bool>.Failure("Кількість товару повинна бути більшою за нуль.");
        }

        if (stock[order.ProductName] < order.Quantity)
        {
            return Result<bool>.Failure("Недостатньо товару на складі.");
        }

        stock[order.ProductName] -= order.Quantity;

        return Result<bool>.Success(true);
    }
}