using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.Review;

namespace Ecommerce.Services.Interfaces;

public interface IReviewService
{
    List<ReviewViewModel> GetAll(int? rating);
    List<ReviewViewModel> GetAll(DateTime? postedDate);
    List<ReviewViewModel> GetAll(string? search);
    ReviewViewModel GetById(int id);
    ReviewViewModel Create(CreateReviewViewModel review);
    void Update(UpdateReviewViewModel review);
    void Delete(int id);
}
