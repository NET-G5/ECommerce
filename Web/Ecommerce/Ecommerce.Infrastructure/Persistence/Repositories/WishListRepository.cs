using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories
{
    public class WishListRepository : RepositoryBase<WishList>, IWishListRepository
    {
        public WishListRepository(EcommerceDbContext context) : base(context) { }

        public List<WishList> GetAll(int? id)
        {
            if (id == null)
            {
                return GetAll();
            }

            var wishLists = _context.WishList
                .Where(x => x.CustomerId == id.Value)
                .ToList();

            return wishLists;
        }
    }
}
