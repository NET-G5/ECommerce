using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.PaymentDetail;

namespace Ecommerce.Services.Interfaces;

public interface IPaymentDetailService
{
    List<PaymentDetailViewModel> GetAll(string? search);
    PaymentDetailViewModel GetById(int id);
    PaymentDetailViewModel Create(CreatePaymentDetailViewModel paymentDetail);
    void Update(UpdatePaymentDetailViewModel paymentDetail);
    void Delete(int id);
}
