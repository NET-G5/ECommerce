using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.Product;

namespace Ecommerce.Services.Interfaces;

public interface IProductService
{
    List<ProductViewModel> GetAll(string? search);
    List<ProductViewModel> GetAll(decimal? price);
    ProductViewModel GetById(int id);
    ProductViewModel Create(CreateProductViewModel product);
    void Update(UpdateProductViewModel product);
    void Delete(int id);
}
