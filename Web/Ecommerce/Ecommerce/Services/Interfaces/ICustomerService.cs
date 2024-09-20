using Ecommerce.Domain.Entities;

namespace Ecommerce.Services.Interfaces;

public interface ICustomerService
{
    List<Customer> GetAll(string? search = null);
    Customer GetById(int id);
    Customer Create(Customer customer);
    void Update(Customer customer);
    void Delete(int id);
}
