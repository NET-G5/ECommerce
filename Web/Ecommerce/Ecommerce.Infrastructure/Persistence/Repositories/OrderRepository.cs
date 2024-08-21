using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(EcommerceDbContext context) : base(context)
    {
    }

    public List<Order> GetAll(decimal? totalAmount)
    {
        if (!totalAmount.HasValue)
        {
            return GetAll();
        }

        var orders = _context.Orders
            .Where(x => x.TotalAmount == totalAmount).ToList();

        return orders;
    }
}
