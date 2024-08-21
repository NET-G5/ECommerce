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
        if (string.IsNullOrEmpty(searchText))
        {
            return GetAll();
        }

        var categories = _context.Categories
            .Where(x => x.Name.Contains(searchText) || 
            x.Description.Contains(searchText)).ToList();

        return categories;
    }
}
