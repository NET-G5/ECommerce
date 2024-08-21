using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(EcommerceDbContext context) : base(context)
    {
    }

    public List<Category> GetAll(string? searchText)
    {
        return [];
    }
}
