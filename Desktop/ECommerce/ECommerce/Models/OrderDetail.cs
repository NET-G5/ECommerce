namespace ECommerce.Models;

public class OrderDetail
{
    public int Id { get; set; }

    public Order Order { get; set; }

    public Product Product { get; set; }

    public OrderStatus Status { get; set; }

    public double Amount { get; set; }

    public double TotalPrice { get; set; }
}
