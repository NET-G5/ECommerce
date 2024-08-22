using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Configurations
{
    public class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetailViewModel>
    {
        public void Configure(EntityTypeBuilder<PaymentDetailViewModel> builder)
        {
            builder.ToTable("PaymentDetail");


        }
    }
}
