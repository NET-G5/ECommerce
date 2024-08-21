using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.ShippingDetail;

namespace Ecommerce.Mappings
{
    public static class ShippingDetailMappings
    {
        public static ShippingDetailViewModel ToViewModel(this ShippingDetail shippingDetail)
        {
            return new ShippingDetailViewModel
            {
                Id = shippingDetail.Id,
                Address = shippingDetail.Address,
                City = shippingDetail.City,
                PostalCode = shippingDetail.PostalCode,
                ShippedDate = shippingDetail.ShippedDate,
                OrderId = shippingDetail.OrderId,
            };
        }
        public static UpdateShippingDetailViewModel ToUpdateViewModel(this ShippingDetailViewModel shippingDetail)
        {
            return new UpdateShippingDetailViewModel
            {
                Id = shippingDetail.Id,
                Address = shippingDetail.Address,
                City = shippingDetail.City,
                PostalCode = shippingDetail.PostalCode,
                ShippedDate = shippingDetail.ShippedDate,
                OrderId = shippingDetail.OrderId,
            };
        }
        public static ShippingDetail ToEntity(this CreateShippingDetailViewModel ShippingDetailViewModel)
        {
            return new ShippingDetail
            {
                Address = ShippingDetailViewModel.Address,
                City = ShippingDetailViewModel.City,
                PostalCode = ShippingDetailViewModel.PostalCode,
                ShippedDate = ShippingDetailViewModel.ShippedDate,
                OrderId = ShippingDetailViewModel.OrderId,
            };
        }
        public static ShippingDetail ToEntity(this UpdateShippingDetailViewModel ShippingDetailViewModel)
        {
            return new ShippingDetail
            {
                Id=ShippingDetailViewModel.Id,
                Address = ShippingDetailViewModel.Address,
                City = ShippingDetailViewModel.City,
                PostalCode = ShippingDetailViewModel.PostalCode,
                ShippedDate = ShippingDetailViewModel.ShippedDate,
                OrderId = ShippingDetailViewModel.OrderId,
            };
        }

    }
}
