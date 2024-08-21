using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class Review : AuditableEntity
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime DatePosted { get; set; }

    public int OrderItemId { get; set; }
    public virtual OrderItem OrderItem { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}
