using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain.Entities;

public class Customer : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public virtual List<Order> Orders { get; set; }
    public virtual List<Review> Reviews { get; set; }
    public virtual WishList WishList { get; set; }
}
