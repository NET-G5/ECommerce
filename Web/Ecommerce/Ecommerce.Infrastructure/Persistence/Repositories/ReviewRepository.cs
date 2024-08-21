using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories;

public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    public ReviewRepository(EcommerceDbContext context) : base(context)
    {
    }

    public List<Review> GetAll(int? rating)
    {
        if (!rating.HasValue)
        {
            return GetAll();
        }

        var reviews = _context.Reviews
            .Where(x => x.Rating == rating)
            .ToList();

        return reviews;
    }

    public List<Review> GetAll(DateTime? postedDate)
    {
        if (!postedDate.HasValue)
        {
            return GetAll();
        }

        var reviews = _context.Reviews
            .Where(x => x.DatePosted == postedDate)
            .ToList();

        return reviews;
    }
}
