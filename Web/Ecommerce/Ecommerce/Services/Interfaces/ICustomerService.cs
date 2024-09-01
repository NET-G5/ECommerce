using Ecommerce.ViewModels.Customer;
using System.Security.Claims;

namespace Ecommerce.Services.Interfaces;

public interface ICustomerService
{
    List<CustomerViewModel> GetAll(string? search);
    CustomerViewModel GetById(int id);
    CustomerViewModel Create(CreateCustomerViewModel customer);
    void Update(UpdateCustomerViewModel customer);
    void Delete(int id);
}
