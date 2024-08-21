using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IWishListRepository : IRepositoryBase<WishList>
{
    List<WishList> GetAll(string? searchText);
}
