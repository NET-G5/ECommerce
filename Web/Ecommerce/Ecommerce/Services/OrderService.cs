using Ecommerce.Application.Mappings;
using Ecommerce.Application.ViewModels.Order;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services;

public class OrderService : IOrderService
{
    private readonly ICommonRepository _commonRepository;

    public OrderService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public List<OrderViewModel> GetAll(decimal? amount)
    {
        var orderViewModel = _commonRepository.Orders.GetAll(amount).Select(x => x.ToViewModel()).ToList();

        return orderViewModel;
    }

    public List<OrderViewModel> GetAll(DateTime? orderDate)
    {
        var orderViewModel = _commonRepository.Orders.GetAll(orderDate).Select(x => x.ToViewModel()).ToList();

        return orderViewModel;
    }

    public List<OrderViewModel> GetAll(OrderStatus? orderStatus)
    {
        var orderViewModel = _commonRepository.Orders.GetAll(orderStatus).Select(x => x.ToViewModel()).ToList();

        return orderViewModel;
    }

    public OrderViewModel Create(CreateOrderViewModel order)
    {
        ArgumentNullException.ThrowIfNull(order);

        var newOrder = _commonRepository.Orders.Create(order.ToEntity());
        _commonRepository.SaveChanges();

        var orderViewModel = newOrder.ToViewModel();

        return orderViewModel;
    }

    public void Delete(int id)
    {
        _commonRepository.Orders.Delete(id);
        _commonRepository.SaveChanges();
    }

    public OrderViewModel GetById(int id)
    {
        var orderViewModel = _commonRepository.Orders.GetById(id).ToViewModel();

        return orderViewModel;
    }

    public void Update(UpdateOrderViewModel order)
    {
        throw new NotImplementedException();
    }

}
