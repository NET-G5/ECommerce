using Ecommerce.Domain.Interfaces;
using Ecommerce.Mappings;
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
        var entities = _commonRepository.Categories.GetAll(search);

        return entities.Select(x => x.ToViewModel()).ToList();

    }

    public CategoryViewModel GetById(int id)
    {
        var entity = _commonRepository.Categories.GetById(id);

        return entity.ToViewModel();
    }

    public CategoryViewModel Create(CreateCategoryViewModel category)
    {
        ArgumentNullException.ThrowIfNull(category);

        var newCategory = _commonRepository.Categories.Create(category.ToEntity());
        _commonRepository.SaveChanges();

        return newCategory.ToViewModel();
    }

    public void Delete(int id)
    {
        _commonRepository.Categories.Delete(id);
        _commonRepository.SaveChanges();
    }


    public void Update(UpdateCategoryViewModel category)
    {
        ArgumentNullException.ThrowIfNull(category);

        var newCategory = category.ToEntity();

        _commonRepository.Categories.Update(newCategory);
        _commonRepository.SaveChanges();
    }
}
