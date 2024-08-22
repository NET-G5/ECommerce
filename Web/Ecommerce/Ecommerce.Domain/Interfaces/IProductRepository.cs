using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IProductRepository : IRepositoryBase<Product>
{
    List<Product> GetAll(string? searchText = null);
    List<Product> GetAll(decimal? price = null);
}
