using Ecommerce.Domain.Interfaces;
using Ecommerce.Mappings;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Category;
using System.Security.Cryptography.Xml;

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
        var categories = _commonRepository.Categories.GetAll(search);

        var categoryViewModels = categories
            .Select(x => x.ToViewModel())
            .ToList();

        return categoryViewModels;

    }

    public CategoryViewModel GetById(int id)
    {
        var category = _commonRepository.Categories.GetById(id);

        var categoryViewModel = category.ToViewModel();

        return categoryViewModel;
    }

    public CategoryViewModel Create(CreateCategoryViewModel categoryViewModel)
    {
        ArgumentNullException.ThrowIfNull(categoryViewModel);

        var category = categoryViewModel.ToEntity();

        var newCategory = _commonRepository.Categories.Create(category);
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

        var entity = category.ToEntity();

        _commonRepository.Categories.Update(entity);
        _commonRepository.SaveChanges();
    }
}
