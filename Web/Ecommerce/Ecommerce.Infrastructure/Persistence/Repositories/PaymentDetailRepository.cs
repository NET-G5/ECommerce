using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

public class PaymentDetailRepository : RepositoryBase<PaymentDetailViewModel>, IPaymentDetailRepository
{
    public PaymentDetailRepository(EcommerceDbContext context) : base(context)
    {
    }

    public List<PaymentDetailViewModel> GetAll(decimal? minValue, decimal? maxValue)
    {
        if (minValue == null && maxValue == null)
        {
            return GetAll();
        }
        else if (maxValue != null && minValue == null)
        {
            return _context.PaymentDetails.Where(x => x.Amount < maxValue).ToList();
        }
        else if (minValue != null && maxValue == null)
        {
            return _context.PaymentDetails.Where(x => x.Amount > minValue).ToList();
        }

        return _context.PaymentDetails.Where(x => x.Amount > minValue && x.Amount < maxValue).ToList();

    }
}
