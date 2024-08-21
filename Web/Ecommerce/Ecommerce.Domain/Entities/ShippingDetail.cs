using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class ShippingDetail : AuditableEntity
{
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public DateTime ShippedDate { get; set; }

    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
}
