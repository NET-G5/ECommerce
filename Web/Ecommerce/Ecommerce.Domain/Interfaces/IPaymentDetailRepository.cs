using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IPaymentDetailRepository : IRepositoryBase<PaymentDetailViewModel>
{
    List<PaymentDetailViewModel> GetAll(decimal? minValue, decimal? maxValue);
}
