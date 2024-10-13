using Ecommerce.Application.ViewModels.Category;

namespace Ecommerce.Services.Interfaces;

public interface ICategoryService
{
    List<CategoryViewModel> GetAll(string? search = null);
    CategoryViewModel GetById(int id);
    CategoryViewModel Create(CreateCategoryViewModel category);
    void Update(UpdateCategoryViewModel category);
    void Delete(int id);
}
