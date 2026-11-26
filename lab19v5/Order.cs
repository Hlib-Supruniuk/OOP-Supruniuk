namespace lab19v5;

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }

    public Order(int id, string productName, int quantity)
    {
        Id = id;
        ProductName = productName;
        Quantity = quantity;
    }
}