﻿using Ecommerce.Application.Mappings;
using Ecommerce.Application.ViewModels.Review;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services;

public class ReviewService : IReviewService
{
    private readonly ICommonRepository _commonRepository;

    public ReviewService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public List<ReviewViewModel> GetAll(string? search)
    {
        var reviews = _commonRepository.Reviews.GetAll(search);

        var viewModels = reviews.Select(x => x.ToViewModel()).ToList();

        return viewModels;
    }

    public List<ReviewViewModel> GetAll(int? rating = null)
    {
        var reviews = _commonRepository.Reviews.GetAll(rating);

        var viewModels = reviews.Select(x => x.ToViewModel()).ToList();

        return viewModels;
    }

    public List<ReviewViewModel> GetAll(DateTime? postedDate = null)
    {
        var reviews = _commonRepository.Reviews.GetAll(postedDate);

        var viewModels = reviews.Select(x => x.ToViewModel()).ToList();

        return viewModels;
    }

    public ReviewViewModel GetById(int id)
    {
        var review = _commonRepository.Reviews.GetById(id);

        var viewModel = review.ToViewModel();

        return viewModel;
    }

    public ReviewViewModel Create(CreateReviewViewModel review)
    {
        ArgumentNullException.ThrowIfNull(review);

        var entity = review.ToEntity();

        _commonRepository.Reviews.Create(entity);
        _commonRepository.SaveChanges();

        var viewModel = entity.ToViewModel();

        return viewModel;
    }

    public void Delete(int id)
    {
        _commonRepository.Reviews.Delete(id);
        _commonRepository.SaveChanges();
    }

    public void Update(UpdateReviewViewModel review)
    {
        ArgumentNullException.ThrowIfNull(review);

        var entity = review.ToEntity();

        _commonRepository.Reviews.Update(entity);
        _commonRepository.SaveChanges();
    }
}
