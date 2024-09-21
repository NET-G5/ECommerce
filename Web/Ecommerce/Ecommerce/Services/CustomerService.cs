using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services;

public class CustomerService : ICustomerService
{
    private readonly ICommonRepository _commonRepository;

    public CustomerService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public List<Customer> GetAll(string? search)
    {
        var customers = _commonRepository.Customers.GetAll(search).ToList();

        return customers;
    }

    public Customer GetById(int id)
    {
        var customer = _commonRepository.Customers.GetById(id);

        return customer;
    }

    public Customer Create(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);

        var newCustomer = _commonRepository.Customers.Create(customer);
        _commonRepository.SaveChanges();

        return newCustomer;
    }

    public void Delete(int id)
    {
        _commonRepository.Customers.Delete(id);
        _commonRepository.SaveChanges();
    }

    public void Update(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);

        _commonRepository.Customers.Update(customer);
        _commonRepository.SaveChanges();
    }
}
