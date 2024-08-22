using Ecommerce.ViewModels.OrderItem;

namespace Ecommerce.Services.Interfaces;

public interface IOrderItemService
{
    List<OrderItemViewModel> GetAll(string? search);
    OrderItemViewModel GetById(int id);
    OrderItemViewModel Create(CreateOrderItemViewModel orderItem);
    void Update(UpdateOrderItemViewModel orderItem);
    void Delete(int id);
}
