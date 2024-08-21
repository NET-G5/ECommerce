namespace Ecommerce.ViewModels.Review
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }
        public int OrderItemId { get; set; }
        public int CustomerId { get; set; }
    }
}
