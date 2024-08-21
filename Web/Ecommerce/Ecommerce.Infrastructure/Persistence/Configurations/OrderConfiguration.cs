using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasMany(x => x.OrderItems)
                .WithOne(c => c.Order)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.PaymentDetail)
                .WithOne(p => p.Order)
                .HasPrincipalKey<PaymentDetail>(x => x.OrderId);

            builder.HasOne(x=>x.ShippingDetail)
                .WithOne(s=>s.Order)
                .HasForeignKey<ShippingDetail>(x => x.OrderId);

        }
    }
}
