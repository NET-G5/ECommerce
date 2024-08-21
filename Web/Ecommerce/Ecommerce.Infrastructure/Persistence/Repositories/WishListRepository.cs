using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Infrastructure.Persistence.Repositories
{
    public class WishListRepository : RepositoryBase<WishList>, IWishList
    {
        public WishListRepository(EcommerceDbContext context) : base(context) { }
    }
}
