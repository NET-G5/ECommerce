using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class ProductsService
    {
        private readonly ECommerceDbContext _context;
        public ProductsService()
        {
            _context = new ECommerceDbContext();
        }
        public List<Product> GetProducts(string searchText="")
        {
            var query = _context.Products
                .AsNoTracking()
                .AsQueryable();

            if(!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => x.Name.Contains(searchText) || x.Description.Contains(searchText));
            }    

            return query.ToList();
        }
        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
