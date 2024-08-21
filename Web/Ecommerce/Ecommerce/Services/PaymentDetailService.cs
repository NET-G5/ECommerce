using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.PaymentDetail;

namespace Ecommerce.Services;

public class PaymentDetailService : IPaymentDetailService
{
    private readonly IPaymentDetailRepository _paymentDetailRepository;

    public PaymentDetailService(IPaymentDetailRepository paymentDetailRepository)
    {
        _paymentDetailRepository = paymentDetailRepository;
    }

    public PaymentDetailViewModel Create(CreatePaymentDetailViewModel paymentDetail)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<PaymentDetailViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public PaymentDetailViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdatePaymentDetailViewModel paymentDetail)
    {
        throw new NotImplementedException();
    }
}
