using Ecommerce.ViewModels.Product;

namespace Ecommerce.ViewModels.WishList
{
    public class WishListViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }

    }
}
