using Ecommerce.Domain.Common;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Entities;

public class Order : AuditableEntity
{
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual PaymentDetail  PaymentDetail { get; set; }
    public virtual ShippingDetail ShippingDetail { get; set; }
}
