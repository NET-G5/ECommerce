namespace Ecommerce.ViewModels.OrderItem
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
