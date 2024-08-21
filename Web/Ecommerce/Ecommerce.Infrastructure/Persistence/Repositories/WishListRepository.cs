﻿using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories
{
    public class WishListRepository : RepositoryBase<WishList>, IWishListRepository
    {
        public WishListRepository(EcommerceDbContext context) : base(context) { }
    }
}
