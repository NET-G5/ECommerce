using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

public class PaymentDetailRepository : RepositoryBase<PaymentDetail>, IPaymentDetail
{
    public PaymentDetailRepository(EcommerceDbContext context) : base(context)
    {
    }
}
