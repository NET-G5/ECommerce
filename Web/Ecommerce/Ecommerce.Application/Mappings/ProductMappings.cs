﻿using Ecommerce.Application.ViewModels.Product;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Mappings
{
    public static class ProductMappings
    {
        public static ProductViewModel ToViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl,
                AddedDate = product.AddedDate,
                CategoryId = product.CategoryId,
            };
        }
        public static UpdateProductViewModel ToUpdateViewModel(this ProductViewModel product)
        {
            return new UpdateProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl,
                AddedDate = product.AddedDate,
                CategoryId = product.CategoryId,
            };
        }
        public static Product ToEntity(this CreateProductViewModel product)
        {
            return new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl,
                AddedDate = product.AddedDate,
                CategoryId = product.CategoryId,
            };
        }
        public static Product ToEntity(this UpdateProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl,
                AddedDate = product.AddedDate,
                CategoryId = product.CategoryId,
            };
        }

    }
}
