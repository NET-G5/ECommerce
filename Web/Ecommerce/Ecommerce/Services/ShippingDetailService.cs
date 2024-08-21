using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.ShippingDetail;

namespace Ecommerce.Services;

public class ShippingDetailService : IShippingDetailService
{
    private readonly IShippingDetailRepository _shippingDetailRepository;

    public ShippingDetailService(IShippingDetailRepository shippingDetailRepository)
    {
        _shippingDetailRepository = shippingDetailRepository;
    }

    public ShippingDetailViewModel Create(CreateShippingDetailViewModel shippingDetail)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<ShippingDetailViewModel> GetAll(DateTime? shippingDate)
    {
        throw new NotImplementedException();
    }

    public List<ShippingDetailViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public ShippingDetailViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateShippingDetailViewModel shippingDetail)
    {
        throw new NotImplementedException();
    }
}
