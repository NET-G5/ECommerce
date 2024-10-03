namespace Ecommerce.Application.ViewModels.Review
{
    public class CreateReviewViewModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }
        public int OrderItemId { get; set; }
        public int CustomerId { get; set; }
    }
}
