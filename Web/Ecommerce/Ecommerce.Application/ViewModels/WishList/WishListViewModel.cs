using Ecommerce.Application.ViewModels.Product;

namespace Ecommerce.Application.ViewModels.WishList
{
    public class WishListViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }

    }
}
