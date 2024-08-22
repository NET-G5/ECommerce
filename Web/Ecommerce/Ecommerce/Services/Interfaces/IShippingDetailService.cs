using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.ShippingDetail;

namespace Ecommerce.Services.Interfaces;

public interface IShippingDetailService
{
    List<ShippingDetailViewModel> GetAll(DateTime? shippingDate=null);
    List<ShippingDetailViewModel> GetAll(string? search=null);
    ShippingDetailViewModel GetById(int id);
    ShippingDetailViewModel Create(CreateShippingDetailViewModel shippingDetail);
    void Update(UpdateShippingDetailViewModel shippingDetail);
    void Delete(int id);
}
