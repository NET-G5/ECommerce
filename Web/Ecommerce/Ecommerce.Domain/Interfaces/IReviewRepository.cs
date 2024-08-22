using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IReviewRepository : IRepositoryBase<Review>
{
    List<Review> GetAll(int? rating = null);
    List<Review> GetAll(DateTime? postedDate = null);
    List<Review> GetAll(string? search = null);
}
