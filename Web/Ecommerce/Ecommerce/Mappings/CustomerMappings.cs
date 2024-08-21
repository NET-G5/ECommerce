using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.Customer;

namespace Ecommerce.Mappings
{
    public static class CustomerMappings
    {
        public static CustomerViewModel ToViewModel(this Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                DateRegistered = customer.DateRegistered,
            };
        }
        public static UpdateCustomerViewModel ToUpdateViewModel(this CustomerViewModel customer)
        {
            return new UpdateCustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                DateRegistered = customer.DateRegistered,
            };
        }
        public static Customer ToEntity(this CreateCustomerViewModel viewModel)
        {
            return new Customer
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                DateRegistered = viewModel.DateRegistered,
            };
        }
        public static Customer ToEntity(this UpdateCustomerViewModel viewModel)
        {
            return new Customer
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                DateRegistered = viewModel.DateRegistered,
            };
        }
    }
}
