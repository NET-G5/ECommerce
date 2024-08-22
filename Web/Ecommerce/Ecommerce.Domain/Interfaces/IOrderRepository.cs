using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Interfaces;

public interface IOrderRepository : IRepositoryBase<Order>
{
    List<Order> GetAll(decimal? totalAmount = null);
    List<Order> GetAll(DateTime? orderDate = null);
    List<Order> GetAll(OrderStatus? orderStatus = null);
}
