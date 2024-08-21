using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

internal class CommonRepository : ICommonRepository
{
    private readonly EcommerceDbContext _context;

    private ICategoryRepository _categoryRepository;
    public ICategoryRepository Categories =>
        _categoryRepository ??= new CategoryRepository(_context);

    public CommonRepository(EcommerceDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        _categoryRepository = new CategoryRepository(context);
    }

    public int SaveChanges()
        => _context.SaveChanges();
}
