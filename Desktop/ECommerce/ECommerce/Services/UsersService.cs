using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Services;

public class UsersService
{
    private readonly ECommerceDbContext _context;

    public UsersService()
    {
        _context = new ECommerceDbContext();
    }

    public List<UserAccount> GetUsers() => [.. _context.Users];
    public UserAccount? GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

    public bool LogIn(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user == null)
        {
            return false;
        }

        return true;
    }
    public bool CreateUser(UserAccount userAccount)
    {
        _context.Users.Add(userAccount);

        int affectedRows = _context.SaveChanges();

        return affectedRows > 0;
    }

    public bool UpdateUser(UserAccount user)
    {
        var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (userToUpdate == null)
        {
            return false;
        }
        _context.Entry(userToUpdate).CurrentValues.SetValues(user);

        int affectedRows = _context.SaveChanges();
        return affectedRows > 0;
    }

    public bool DeleteUser(UserAccount user)
    {
        var userToDelete = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (userToDelete == null)
        {
            return false;
        }

        _context.Users.Remove(userToDelete);

        int affectedRows = _context.SaveChanges();
        return affectedRows > 0;
    }
}
