using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.WishList;

namespace Ecommerce.Mappings
{
    public static class WishListMappings
    {
        public static WishListViewModel ToViewModel(this WishList wishList)
        {
            return new WishListViewModel
            {
                Id = wishList.Id,
                CustomerId = wishList.CustomerId,
            };
        }
        public static UpdateWishListViewModel ToUpdateViewModel(this WishListViewModel wishList)
        {
            return new UpdateWishListViewModel
            {
                Id = wishList.Id,
                CustomerId = wishList.CustomerId,
            };
        }
        public static WishList ToEntity(this CreateWishListViewModel wishList)
        {
            return new WishList
            {
                CustomerId = wishList.CustomerId,
            };
        }
        public static WishList ToEntity(this UpdateWishListViewModel wishList)
        {
            return new WishList
            {
                Id = wishList.Id,
                CustomerId = wishList.CustomerId,
            };
        }
    }
}
