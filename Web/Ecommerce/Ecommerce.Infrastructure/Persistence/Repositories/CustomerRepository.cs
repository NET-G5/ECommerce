using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(EcommerceDbContext context) : base(context)
    {
    }

    public List<Customer> GetAll(string? searchText)
    {
        throw new NotImplementedException();
    }
}
