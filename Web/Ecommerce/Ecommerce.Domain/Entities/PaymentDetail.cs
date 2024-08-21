using Ecommerce.Domain.Common;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Entities;

public class PaymentDetail : AuditableEntity
{
    public PaymentMethod Method { get; set; } 
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    
    public virtual List<Order> Orders { get; set; }
}
