using Ecommerce.Domain.Enums;

namespace Ecommerce.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }

    }
}
