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
    public class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            builder.ToTable("PaymentDetail");

            
        }
    }
}
