using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.OrderItem;

namespace Ecommerce.Mappings
{
    public static class OrderItemMappings
    {
        public static OrderItemViewModel ToViewModel(this OrderItem orderItem)
        {
            return new OrderItemViewModel
            {
                Id = orderItem.Id,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
            };
        }
        public static UpdateOrderItemViewModel ToUpdateViewModel(this OrderItemViewModel orderItemViewModel)
        {
            return new UpdateOrderItemViewModel
            {
                Id = orderItemViewModel.Id,
                Quantity = orderItemViewModel.Quantity,
                UnitPrice = orderItemViewModel.UnitPrice,
                OrderId = orderItemViewModel.OrderId,
                ProductId = orderItemViewModel.ProductId,
            };
        }
        public static OrderItem ToEntity(this CreateOrderItemViewModel orderItem)
        {
            return new OrderItem
            {
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
            };
        }
        public static OrderItem ToEntity(this UpdateOrderItemViewModel orderItem)
        {
            return new OrderItem
            {
                Id = orderItem.Id,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
            };
        }
        
    }
}