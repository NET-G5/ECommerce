using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasMany(p => p.Reviews)
                    .WithOne(r => r.OrderItem)
                    .HasForeignKey(r => r.OrderItemId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
