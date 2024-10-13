using Ecommerce.Domain.Enums;

namespace Ecommerce.Application.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public int CustomerId { get; set; }

    }
}
