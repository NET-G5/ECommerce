namespace ECommerce.Models;

public class Order
{
    public int Id { get; set; }

    public UserAccount UserAccount { get; set; }
    public int UserAccountId { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatedDate { get; set; }

}
