
﻿using Ecommerce.Domain.Interfaces;
using Ecommerce.Mappings;

using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Customer;

namespace Ecommerce.Services;

public class CustomerService : ICustomerService
{
    private readonly ICommonRepository _commonRepository;

    public CustomerService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }


    public List<CustomerViewModel> GetAll(string? search)

    {
        var customers = _commonRepository.Customers.GetAll(search).ToList();

        var customerViewModel = customers.Select(x => x.ToViewModel()).ToList();

        return customerViewModel;
    }


    public CustomerViewModel GetById(int id)

    {
        var customer = _commonRepository.Customers.GetById(id);

        var customerViewModel = customer.ToViewModel();

        return customerViewModel;
    }


    public CustomerViewModel Create(CreateCustomerViewModel customer)

    {
        ArgumentNullException.ThrowIfNull(customer);

        var newCustomer = _commonRepository.Customers.Create(customer.ToEntity());
        _commonRepository.SaveChanges();

        return newCustomer.ToViewModel();
    }


    public void Delete(int id)
    {
        _commonRepository.Customers.Delete(id);
        _commonRepository.SaveChanges();
    }


    public void Update(UpdateCustomerViewModel customer)
    {
        ArgumentNullException.ThrowIfNull(customer);

        var customerToUpdate = customer.ToEntity();

        _commonRepository.Customers.Update(customerToUpdate);
        _commonRepository.SaveChanges();
    }
}
