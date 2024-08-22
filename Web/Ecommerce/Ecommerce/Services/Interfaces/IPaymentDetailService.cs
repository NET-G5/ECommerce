using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.PaymentDetail;

namespace Ecommerce.Services.Interfaces;

public interface IPaymentDetailService
{
    List<PaymentDetailViewModel> GetAll(decimal? minValue =null, decimal? maxValue=null);
    PaymentDetailViewModel GetById(int id);
    PaymentDetailViewModel Create(CreatePaymentDetailViewModel paymentDetail);
    void Update(UpdatePaymentDetailViewModel paymentDetail);
    void Delete(int id);
}
