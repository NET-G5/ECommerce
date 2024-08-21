using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Review;

namespace Ecommerce.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public ReviewViewModel Create(CreateReviewViewModel review)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<ReviewViewModel> GetAll(int? rating)
    {
        throw new NotImplementedException();
    }

    public List<ReviewViewModel> GetAll(DateTime? postedDate)
    {
        throw new NotImplementedException();
    }

    public List<ReviewViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public ReviewViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateReviewViewModel review)
    {
        throw new NotImplementedException();
    }
}
