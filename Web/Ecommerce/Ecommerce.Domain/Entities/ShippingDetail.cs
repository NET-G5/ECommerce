namespace Ecommerce.Domain.Entities;

public class ShippingDetail
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public DateTime ShippedDate { get; set; }
    
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
}
