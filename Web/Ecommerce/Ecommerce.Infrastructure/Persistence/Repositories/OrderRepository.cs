using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
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
        if (totalAmount == null)
        {
            return GetAll();
        }

        var orders = _context.Orders
            .Where(x => x.TotalAmount == totalAmount).ToList();

        return orders;
    }

    public List<Order> GetAll(DateTime? orderDate)
    {
        if (orderDate == null)
        {
            return GetAll();
        }

        var orders = _context.Orders
            .Where(x => x.OrderDate == orderDate).ToList();

        return orders;
    }

    public List<Order> GetAll(OrderStatus? orderStatus)
    {
        if (orderStatus == null)
        {
            return GetAll();
        }

        var orders = _context.Orders
            .Where(x => x.Status == orderStatus).ToList();

        return orders;
    }
}
