namespace ECommerce.Models;

public class UserAccount
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Reviews> Reviews { get; set; }
    public virtual ICollection<Order> Orders { get; set; }

    public UserAccount()
    {
        Reviews = new List<Reviews>();
        Orders = new List<Order>();
    }
}
