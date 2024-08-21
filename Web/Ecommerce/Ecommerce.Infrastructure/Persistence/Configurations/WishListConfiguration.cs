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
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.ToTable("WishList");

            builder.HasOne(w => w.Customer)
                .WithOne(c => c.WishList)
                .HasForeignKey<WishList>(x => x.CustomerId);

            builder.HasMany(x => x.Products)
                .WithMany();
        }
    }
}
