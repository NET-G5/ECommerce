using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.Review;

namespace Ecommerce.Mappings
{
    public static class ReviewMappings
    {
        public static ReviewViewModel ToViewModel(this Review review)
        {
            return new ReviewViewModel
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                DatePosted = review.DatePosted,
                OrderItemId = review.OrderItemId,
                CustomerId = review.CustomerId,
            };
        }
        public static UpdateReviewViewModel ToUpdateViewModel(this ReviewViewModel review)
        {
            return new UpdateReviewViewModel
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                DatePosted = review.DatePosted,
                OrderItemId = review.OrderItemId,
                CustomerId = review.CustomerId,
            };
        }
        public static Review ToEntity(this CreateReviewViewModel viewModel)
        {
            return new Review
            {
                Rating = viewModel.Rating,
                Comment = viewModel.Comment,
                DatePosted = viewModel.DatePosted,
                OrderItemId = viewModel.OrderItemId,
                CustomerId = viewModel.CustomerId,
            };
        }
        public static Review ToEntity(this UpdateReviewViewModel viewModel)
        {
            return new Review
            {
                Id = viewModel.Id,
                Rating = viewModel.Rating,
                Comment = viewModel.Comment,
                DatePosted = viewModel.DatePosted,
                OrderItemId = viewModel.OrderItemId,
                CustomerId = viewModel.CustomerId,
            };
        }

    }
}
