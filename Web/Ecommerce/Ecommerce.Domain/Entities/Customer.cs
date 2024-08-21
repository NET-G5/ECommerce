using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public class Customer :AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateRegistered { get; set; }
}
