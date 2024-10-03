namespace Ecommerce.Application.ViewModels.OrderItem
{
    public class CreateOrderItemViewModel
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
