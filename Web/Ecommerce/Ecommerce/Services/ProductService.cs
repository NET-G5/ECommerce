using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Product;

namespace Ecommerce.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public ProductViewModel Create(CreateProductViewModel product)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<ProductViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public List<ProductViewModel> GetAll(decimal? price)
    {
        throw new NotImplementedException();
    }

    public ProductViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateProductViewModel product)
    {
        throw new NotImplementedException();
    }
}
