using Azure.Core;
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
        if (!string.IsNullOrEmpty(searchText))
        {
            return GetAll();
        }

        var products = _context.Products
            .Where(x => x.Name.Contains(searchText!)).ToList();

        return products;
    }

    public List<Product> GetAll(decimal? price)
    {
        if (!price.HasValue)
        {
            return GetAll();
        }

        var products = _context.Products
            .Where(x => x.Price == price).ToList();

        return products;
    }
}
