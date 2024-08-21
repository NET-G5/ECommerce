using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.OrderItem;

namespace Ecommerce.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderRepository _orderRepository;
    public OrderItemService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public OrderItemViewModel Create(CreateOrderItemViewModel orderItem)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<OrderItemViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public OrderItemViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateOrderItemViewModel orderItem)
    {
        throw new NotImplementedException();
    }
}
