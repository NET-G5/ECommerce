using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Customer;

namespace Ecommerce.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public CustomerViewModel Create(CreateCustomerViewModel customer)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<CustomerViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public CustomerViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateCustomerViewModel customer)
    {
        throw new NotImplementedException();
    }
}
