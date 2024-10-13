using Ecommerce.Application.Mappings;
using Ecommerce.Application.ViewModels.Product;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services;

public class ProductService : IProductService
{
    private readonly ICommonRepository _commonRepository;

    public ProductService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }
    public ProductViewModel Create(CreateProductViewModel product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var entity = product.ToEntity();

        _commonRepository.Products.Create(entity);
        _commonRepository.SaveChanges();

        var viewModel = entity.ToViewModel();

        return viewModel;
    }

    public void Delete(int id)
    {
        _commonRepository.Products.Delete(id);
        _commonRepository.SaveChanges();
    }

    public List<ProductViewModel> GetAll(string? search)
    {
        var products = _commonRepository.Products.GetAll(search);

        var viewModel = products.Select(x => x.ToViewModel()).ToList();

        return viewModel;
    }

    public List<ProductViewModel> GetAll(decimal? price)
    {
        var products = _commonRepository.Products.GetAll(price);

        var viewModel = products.Select(x => x.ToViewModel()).ToList();

        return viewModel;
    }

    public ProductViewModel GetById(int id)
    {
        var product = _commonRepository.Products.GetById(id);

        var viewModel = product.ToViewModel();

        return viewModel;
    }

    public void Update(UpdateProductViewModel product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var entity = product.ToEntity();

        _commonRepository.Products.Update(entity);
        _commonRepository.SaveChanges();
    }
}
