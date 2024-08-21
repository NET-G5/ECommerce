using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Category;

namespace Ecommerce.Services;

public class CategoryService : ICategoryService
{
    private readonly ICommonRepository _commonRepository;

    public CategoryService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }
    public List<CategoryViewModel> GetAll(string? search)
    {
        var entity = _commonRepository.Categories.GetAll(search);
        throw new NotImplementedException();

    }

    public CategoryViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public CategoryViewModel Create(CreateCategoryViewModel category)
    {
        throw new NotImplementedException();

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }


    public void Update(UpdateCategoryViewModel category)
    {
        throw new NotImplementedException();
    }
}
