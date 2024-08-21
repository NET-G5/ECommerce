using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public byte[] Image { get; set; }
    public DateTime AddedDate { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}