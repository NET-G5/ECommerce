using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Order;

namespace Ecommerce.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public OrderViewModel Create(CreateOrderViewModel order)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<OrderViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public List<OrderViewModel> GetAll(decimal? amount)
    {
        throw new NotImplementedException();
    }

    public OrderViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateOrderViewModel order)
    {
        throw new NotImplementedException();
    }
}
