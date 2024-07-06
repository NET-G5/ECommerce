namespace ECommerce.Models;

public class Order
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime OrderedDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public DateTime? SoldDate { get; set; }
}
