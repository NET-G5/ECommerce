﻿using Ecommerce.Domain.Interfaces;
using Ecommerce.Mappings;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Product;

namespace Ecommerce.Services;

public class ProductService : IProductService
{
    private readonly ICommonRepository _commonRepository;

    public ProductService(ICommonRepository commonRepository)
    {
        _commonRepository= commonRepository;
    }
    public ProductViewModel Create(CreateProductViewModel product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var entity = product.ToEntity();

        _commonRepository.Products.Create(entity);
        _commonRepository.SaveChanges();

        var viewModel=entity.ToViewModel();

        return viewModel;
    }

    public void Delete(int id)
    {
        _commonRepository.Products.Delete(id);
        _commonRepository.SaveChanges();
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
        var product=_commonRepository.Products.GetById(id);

        var viewModel=product.ToViewModel();

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