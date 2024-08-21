namespace Ecommerce.Domain.Entities;

public class WishList
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public ICollection<Product> Products { get; set; }
}
