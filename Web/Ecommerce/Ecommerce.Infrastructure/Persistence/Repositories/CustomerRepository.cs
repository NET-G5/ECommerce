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
        if (string.IsNullOrEmpty(searchText))
        {
            return GetAll();
        }

        var customers = _context.Customers
            .Where(x => x.FirstName.Contains(searchText) ||
            x.LastName.Contains(searchText) ||
            x.Email.Contains(searchText)).ToList();

        return customers;
    }
}
