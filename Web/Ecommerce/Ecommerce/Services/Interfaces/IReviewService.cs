using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.Review;

namespace Ecommerce.Services.Interfaces;

public interface IReviewService
{
    List<ReviewViewModel> GetAll(int? rating=null);
    List<ReviewViewModel> GetAll(DateTime? postedDate = null);
    List<ReviewViewModel> GetAll(string? search = null);
    ReviewViewModel GetById(int id);
    ReviewViewModel Create(CreateReviewViewModel review);
    void Update(UpdateReviewViewModel review);
    void Delete(int id);
}
