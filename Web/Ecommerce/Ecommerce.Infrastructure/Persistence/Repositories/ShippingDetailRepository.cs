using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ShippingDetailRepository : RepositoryBase<ShippingDetail>, IShippingDetail
    {
        public ShippingDetailRepository(EcommerceDbContext context) : base(context)
        {
        }

        public List<ShippingDetail> GetAll(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return GetAll();
            }

            var shippingDetails = _context.ShippingDetails
                .Where(x => x.PostalCode.Contains(searchText) ||
                            x.Address.Contains(searchText) ||
                            x.City.Contains(searchText)).ToList();

            return shippingDetails;
        }

        public List<ShippingDetail> GetAll(DateTime? shippedDate)
        {
            if (!shippedDate.HasValue)
            {
                return GetAll();
            }

            var shippingDetails = _context.ShippingDetails
                .Where(x => x.ShippedDate == shippedDate).ToList();

            return shippingDetails;
        }
    }
}
