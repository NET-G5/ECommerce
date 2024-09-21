using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{

    public readonly EcommerceDbContext _context;

    public CustomerRepository(EcommerceDbContext context)
    {
        _context = context;
    }
    public Customer Create(Customer entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<Customer>().Add(entity);

        return entity;
    }

    public void Delete(int id)
    {
        var entity = GetOrThrow(id);

        _context.Set<Customer>().Remove(entity);
    }
    public List<Customer> GetAll()
        => _context.Set<Customer>().AsNoTracking().ToList();

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

    public Customer GetById(int id)
        => GetOrThrow(id);

    public void Update(Customer entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Set<Customer>().Update(entity);
    }

    private Customer GetOrThrow(int id)
    {
        var entity = _context.Set<Customer>().FirstOrDefault(x => x.Id == id);

        if (entity is null)
        {
            throw new EntityNotFoundException($"{typeof(Customer)} with id: {id} not found.");
        }

        return entity;
    }
}
