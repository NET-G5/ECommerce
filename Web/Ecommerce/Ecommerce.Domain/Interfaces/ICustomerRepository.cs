using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    List<Customer> GetAll(string? searchText);
}
