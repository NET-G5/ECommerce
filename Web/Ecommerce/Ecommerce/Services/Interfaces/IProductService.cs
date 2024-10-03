using Ecommerce.Application.ViewModels.Product;

namespace Ecommerce.Services.Interfaces;

public interface IProductService
{
    List<ProductViewModel> GetAll(string? search = null);
    List<ProductViewModel> GetAll(decimal? price = null);
    ProductViewModel GetById(int id);
    ProductViewModel Create(CreateProductViewModel product);
    void Update(UpdateProductViewModel product);
    void Delete(int id);
}
