using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.Category;

namespace Ecommerce.Mappings
{
    public static class CategoryMappings
    {
        public static CategoryViewModel ToViewModel(this Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }
        public static UpdateCategoryViewModel ToUpdateViewModel(this CategoryViewModel category)
        {
            return new UpdateCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }
        public static Category ToEntity(this CreateCategoryViewModel category)
        {
            return new Category
            {
                Name = category.Name,
                Description = category.Description,
            };
        }
        public static Category ToEntity(this UpdateCategoryViewModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }

    }
}
