using Ecommerce.ViewModels.WishList;

namespace Ecommerce.Services.Interfaces;

public interface IWishListService
{
    List<WishListViewModel> GetAll(int? id = null);
    WishListViewModel GetById(int id);
    WishListViewModel Create(CreateWishListViewModel wishList);
    void Update(UpdateWishListViewModel wishList);
    void Delete(int id);
}
