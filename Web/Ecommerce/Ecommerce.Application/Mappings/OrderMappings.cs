using Ecommerce.Application.ViewModels.Order;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mappings
{
    public static class OrderMappings
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CustomerId = order.CustomerId,
            };
        }
        public static UpdateOrderViewModel ToUpdateViewModel(this OrderViewModel order)
        {
            return new UpdateOrderViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CustomerId = order.CustomerId,
            };
        }
        public static Order ToEntity(this CreateOrderViewModel order)
        {
            return new Order
            {
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CustomerId = order.CustomerId,
            };
        }
        public static Order ToEntity(this UpdateOrderViewModel order)
        {
            return new Order
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CustomerId = order.CustomerId,
            };
        }

    }
}
