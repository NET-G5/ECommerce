using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IReviewRepository : IRepositoryBase<Review>
{
    List<Review> GetAll(int? rating);
    List<Review> GetAll(DateTime? postedDate);
}
