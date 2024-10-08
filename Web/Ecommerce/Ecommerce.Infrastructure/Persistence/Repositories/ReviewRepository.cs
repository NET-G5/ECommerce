﻿using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    public ReviewRepository(EcommerceDbContext context) : base(context)
    {
    }

    public List<Review> GetAll(int? rating)
    {
        if (rating == null)
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
        if (postedDate == null)
        {
            return GetAll();
        }

        var reviews = _context.Reviews
            .Where(x => x.DatePosted == postedDate)
            .ToList();

        return reviews;
    }
    public List<Review> GetAll(string? search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return GetAll();
        }

        var reviews = _context.Reviews
            .Where(x => x.Comment.Contains(search))
            .ToList();

        return reviews;
    }

}
