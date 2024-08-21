using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface ICategoryRepository : IRepositoryBase<Category>
{
    List<Category> GetAll(string? searchText);
}
