using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IShippingDetailRepository : IRepositoryBase<ShippingDetail>
{
    List<ShippingDetail> GetAll(string? searchText);
    List<ShippingDetail> GetAll(DateTime? shippedDate);
}
