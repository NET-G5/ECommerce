using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

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
