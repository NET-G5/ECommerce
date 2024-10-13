using Ecommerce.Application.Mappings;
using Ecommerce.Application.ViewModels.WishList;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Services.Interfaces;

namespace Ecommerce.Services;

public class WishListService : IWishListService
{
    private readonly ICommonRepository _commonRepository;

    public WishListService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public List<WishListViewModel> GetAll(int? id)
    {
        var wishLists = _commonRepository.WishLists.GetAll(id);

        var viewModel = wishLists.Select(x => x.ToViewModel()).ToList();

        return viewModel;
    }

    public WishListViewModel GetById(int id)
    {
        var wishList = _commonRepository.WishLists.GetById(id);

        var viewModel = wishList.ToViewModel();

        return viewModel;
    }
    public WishListViewModel Create(CreateWishListViewModel wishList)
    {
        ArgumentNullException.ThrowIfNull(wishList);

        var entity = wishList.ToEntity();

        _commonRepository.WishLists.Create(entity);
        _commonRepository.SaveChanges();

        var viewModel = entity.ToViewModel();

        return viewModel;
    }

    public void Update(UpdateWishListViewModel wishList)
    {
        ArgumentNullException.ThrowIfNull(wishList);

        var entity = wishList.ToEntity();

        _commonRepository.WishLists.Update(entity);
        _commonRepository.SaveChanges();
    }

    public void Delete(int id)
    {
        _commonRepository.WishLists.Delete(id);
        _commonRepository.SaveChanges();
    }
}
