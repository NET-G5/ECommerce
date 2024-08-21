﻿using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces;

public interface IWishList : IRepositoryBase<WishList>
{
    List<Review> GetAll(string? searchText);
}