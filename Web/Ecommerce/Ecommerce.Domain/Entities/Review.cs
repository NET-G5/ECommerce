namespace Ecommerce.Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }  // e.g., 1 to 5 stars
    public string Comment { get; set; }
    public DateTime DatePosted { get; set; }
    
    public int OrderItemId { get; set; }
    public virtual OrderItem OrderItem { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}
