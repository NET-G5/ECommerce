using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.WishList;

namespace Ecommerce.Services;

public class WishListService : IWishListService
{
    private readonly IWishListRepository _wishListRepository;

    public WishListService(IWishListRepository wishListRepository)
    {
        _wishListRepository = wishListRepository;
    }

    public WishListViewModel Create(CreateWishListViewModel wishList)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<WishListViewModel> GetAll(string? search)
    {
        throw new NotImplementedException();
    }

    public WishListViewModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateWishListViewModel wishList)
    {
        throw new NotImplementedException();
    }
}
