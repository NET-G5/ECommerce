using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public class PaymentDetailRepository : RepositoryBase<PaymentDetail>, IPaymentDetail
{
    public PaymentDetailRepository(EcommerceDbContext context) : base(context)
    {
    }
}
