namespace Ecommerce.ViewModels.ShippingDetail
{
    public class CreateShippingDetailViewModel
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime ShippedDate { get; set; }
        public int OrderId { get; set; }
    }
}
