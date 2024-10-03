using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IPaymentDetailRepository : IRepositoryBase<PaymentDetail>
{
    List<PaymentDetail> GetAll(decimal? minValue, decimal? maxValue);
}
