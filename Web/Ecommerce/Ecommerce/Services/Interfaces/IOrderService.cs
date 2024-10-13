using Ecommerce.Application.ViewModels.Order;

namespace Ecommerce.Services.Interfaces;

public interface IOrderService
{
    List<OrderViewModel> GetAll(DateTime? orderedDate = null);
    List<OrderViewModel> GetAll(decimal? amount = null);
    OrderViewModel GetById(int id);
    OrderViewModel Create(CreateOrderViewModel order);
    void Update(UpdateOrderViewModel order);
    void Delete(int id);
}
