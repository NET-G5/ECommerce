namespace Ecommerce.Application.ViewModels.ShippingDetail
{
    public class ShippingDetailViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime ShippedDate { get; set; }
        public int OrderId { get; set; }
    }
}
