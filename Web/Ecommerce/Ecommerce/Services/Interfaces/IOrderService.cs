using Ecommerce.Domain.Enums;
using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.Order;

namespace Ecommerce.Services.Interfaces;

public interface IOrderService
{
    List<OrderViewModel> GetAll(decimal? amount = null);
    List<OrderViewModel> GetAll(DateTime? orderDate = null);
    List<OrderViewModel> GetAll(OrderStatus? orderStatus = null);
    OrderViewModel GetById(int id);
    OrderViewModel Create(CreateOrderViewModel order);
    void Update(UpdateOrderViewModel order);
    void Delete(int id);
}
