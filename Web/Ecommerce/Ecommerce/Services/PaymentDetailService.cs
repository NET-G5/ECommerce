using Ecommerce.Domain.Interfaces;
using Ecommerce.Mappings;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.PaymentDetail;

namespace Ecommerce.Services;

public class PaymentDetailService : IPaymentDetailService
{
    private readonly ICommonRepository _commonRepository;

    public PaymentDetailService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public PaymentDetailViewModel Create(CreatePaymentDetailViewModel paymentDetail)
    {
        ArgumentNullException.ThrowIfNull(paymentDetail);

        var entity = paymentDetail.ToEntity();

        _commonRepository.PaymentDetails.Create(entity);
        _commonRepository.SaveChanges();

        var viewModel = entity.ToViewModel();

        return viewModel;
    }

    public void Delete(int id)
    {
        _commonRepository.PaymentDetails.Delete(id);
        _commonRepository.SaveChanges();
    }

    public List<PaymentDetailViewModel> GetAll(decimal? minValue, decimal? maxValue)
    {
        var paymentDetails = _commonRepository.PaymentDetails.GetAll(minValue, maxValue);

        var viewModel = paymentDetails.Select(x => x.ToViewModel()).ToList();

        return viewModel;
    }



    public PaymentDetailViewModel GetById(int id)
    {
        var paymentDatail = _commonRepository.PaymentDetails.GetById(id);

        var viewModel = paymentDatail.ToViewModel();

        return viewModel;
    }

    public void Update(UpdatePaymentDetailViewModel paymentDetail)
    {
        ArgumentNullException.ThrowIfNull(paymentDetail);

        var entity = paymentDetail.ToEntity();

        _commonRepository.PaymentDetails.Update(entity);
        _commonRepository.SaveChanges();
    }
}
