using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class WishList : AuditableEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public ICollection<Product> Products { get; set; }
}
