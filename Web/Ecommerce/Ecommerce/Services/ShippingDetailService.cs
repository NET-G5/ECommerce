using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Mappings;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.ShippingDetail;

namespace Ecommerce.Services;

public class ShippingDetailService : IShippingDetailService
{
    private readonly ICommonRepository _commonRepository;

    public ShippingDetailService(ICommonRepository commonRepository)
    {
        _commonRepository= commonRepository;
    }

    public List<ShippingDetailViewModel> GetAll(DateTime? shippingDate)
    {
        var shippingDetails=_commonRepository.ShippingDetails.GetAll(shippingDate);

        var viewModels=shippingDetails.Select(x=>x.ToViewModel()).ToList();

        return viewModels;
    }

    public List<ShippingDetailViewModel> GetAll(string? search)
    {

        var shippingDetails = _commonRepository.ShippingDetails.GetAll(search);

        var viewModels = shippingDetails.Select(x => x.ToViewModel()).ToList();

        return viewModels;
    }

    public ShippingDetailViewModel GetById(int id)
    {
        var shippingDetail= _commonRepository.ShippingDetails.GetById(id);
        
        var viewModel=shippingDetail.ToViewModel();

        return viewModel;
    }

    public ShippingDetailViewModel Create(CreateShippingDetailViewModel shippingDetail)
    {
        ArgumentNullException.ThrowIfNull(shippingDetail);

        var entity=shippingDetail.ToEntity();

        _commonRepository.ShippingDetails.Create(entity);
        _commonRepository.SaveChanges();

        var viewModel= entity.ToViewModel();

        return viewModel;
    }

    public void Update(UpdateShippingDetailViewModel shippingDetail)
    {
        ArgumentNullException.ThrowIfNull(shippingDetail);

        var entity=shippingDetail.ToEntity();

        _commonRepository.ShippingDetails.Update(entity);
        _commonRepository.SaveChanges() ;
    }
    public void Delete(int id)
    {
        _commonRepository.ShippingDetails.Delete(id);
        _commonRepository.SaveChanges() ;
    }
}
