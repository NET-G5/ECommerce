using Bogus;
using ECommerce.Data;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    class DataSeederService
    {
        private static readonly Faker faker = new Faker();
        public static void SeedDate()
        {
            using var context = new ECommerceDbContext();
            CreateProducts(context);
            CreateCategories(context);
        }
        private static void CreateProducts(ECommerceDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }
            var categoryIds = context.Categories.Select(x => x.Id).ToArray();
            foreach (var categoryId in categoryIds)
            {

                for (int i = 0; i < 100; i++)
                {
                    var product = new Product();
                    product.Name = faker.Commerce.ProductName();
                    product.Description = faker.Commerce.ProductDescription();
                    product.Price = decimal.Parse(faker.Commerce.Price(100, 10000));
                    product.ImageUrl = faker.Image.PicsumUrl();
                    product.StockQuantity = faker.Random.Short();

                    context.Products.Add(product);
                }
                context.SaveChanges();
            }

        }
        private static void CreateCategories(ECommerceDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                var category = new Category();
                category.Name = faker.Commerce.Categories(10).First();
                category.Description = faker.Commerce.ProductDescription();

                context.Categories.Add(category);
            }
            context.SaveChanges();
        }
    }
}
