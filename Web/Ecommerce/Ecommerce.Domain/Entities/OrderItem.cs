using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class OrderItem : AuditableEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
