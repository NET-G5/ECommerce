using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IShippingDetail : IRepositoryBase<ShippingDetail>
{
    List<ShippingDetail> GetAll(string? searchText);
    List<ShippingDetail> GetAll(DateTime? shippedDate);
}
