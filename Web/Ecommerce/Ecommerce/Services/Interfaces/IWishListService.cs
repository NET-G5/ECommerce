using Ecommerce.ViewModels.Category;
using Ecommerce.ViewModels.WishList;

namespace Ecommerce.Services.Interfaces;

public interface IWishListService
{
    List<WishListViewModel> GetAll(string? search);
    WishListViewModel GetById(int id);
    WishListViewModel Create(CreateWishListViewModel wishList);
    void Update(UpdateWishListViewModel wishList);
    void Delete(int id);
}
