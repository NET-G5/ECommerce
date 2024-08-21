using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(EcommerceDbContext context) : base(context)
    {
    }

    public List<Product> GetAll(string? searchText)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll(decimal? price)
    {
        throw new NotImplementedException();
    }
}
