using Ecommerce.Application.Mappings;
using Ecommerce.Application.ViewModels.OrderItem;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services;

public class OrderItemService : IOrderItemService
{
    private readonly ICommonRepository _commonRepository;
    public OrderItemService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public List<OrderItemViewModel> GetAll()
    {
        var orderItemViewModels = _commonRepository.OrderItems
                .GetAll().Select(x => x.ToViewModel()).ToList();

        return orderItemViewModels;
    }

    public OrderItemViewModel GetById(int id)
    {
        var orderItemViewModel = _commonRepository.OrderItems
            .GetById(id).ToViewModel();

        return orderItemViewModel;
    }

    public OrderItemViewModel Create(CreateOrderItemViewModel orderItem)
    {
        ArgumentNullException.ThrowIfNull(orderItem);

        var newOrderItem = _commonRepository.OrderItems.Create(orderItem.ToEntity());
        _commonRepository.SaveChanges();

        var orderItemViewModel = newOrderItem.ToViewModel();

        return orderItemViewModel;

    }

    public void Delete(int id)
    {
        _commonRepository.OrderItems.Delete(id);
        _commonRepository.SaveChanges();
    }


    public void Update(UpdateOrderItemViewModel orderItem)
    {
        ArgumentNullException.ThrowIfNull(orderItem);

        var orderItemToUpdate = orderItem.ToEntity();

        _commonRepository.OrderItems.Update(orderItemToUpdate);
        _commonRepository.SaveChanges();
    }
}
