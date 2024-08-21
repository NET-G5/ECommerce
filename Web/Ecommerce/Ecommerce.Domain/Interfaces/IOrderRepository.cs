using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IOrderRepository : IRepositoryBase<Order>
{
    List<Order> GetAll(decimal? totalAmount);
}
