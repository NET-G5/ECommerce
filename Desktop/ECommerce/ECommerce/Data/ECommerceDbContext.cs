using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data;

public class ECommerceDbContext : DbContext
{
    public virtual DbSet<UserAccount> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Reviews> Reviews { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

    public ECommerceDbContext()
    {
        Database.SetCommandTimeout(TimeSpan.FromMinutes(10));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-J7QN3MV\\SQLEXPRESS;Initial Catalog=ecommerce_management_system_ef;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccount>()
            .ToTable(nameof(UserAccount));
        modelBuilder.Entity<UserAccount>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Product>()
            .ToTable(nameof(Product));
        modelBuilder.Entity<Product>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Reviews>()
            .ToTable(nameof(Reviews));
        modelBuilder.Entity<Reviews>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Category>()
            .ToTable(nameof(Category));
        modelBuilder.Entity<Category>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Order>()
            .ToTable(nameof(Order));
        modelBuilder.Entity<Order>()
            .HasKey(u => u.Id);
    }
}
