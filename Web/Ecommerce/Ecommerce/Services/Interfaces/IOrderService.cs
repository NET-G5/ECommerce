using Ecommerce.ViewModels.Order;

namespace Ecommerce.Services.Interfaces;

public interface IOrderService
{
    List<OrderViewModel> GetAll(string? search);
    List<OrderViewModel> GetAll(decimal? amount);
    OrderViewModel GetById(int id);
    OrderViewModel Create(CreateOrderViewModel order);
    void Update(UpdateOrderViewModel order);
    void Delete(int id);
}
