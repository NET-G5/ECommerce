using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class Category : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
