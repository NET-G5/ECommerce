using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.PaymentDetail;

namespace Ecommerce.Mappings
{
    public static class PaymentDetailMappings
    {
        public static PaymentDetailViewModel ToViewModel(this PaymentDetail paymentDetail)
        {
            return new PaymentDetailViewModel
            {
                Id = paymentDetail.Id,
                Method = paymentDetail.Method,
                PaymentDate = paymentDetail.PaymentDate,
                Amount = paymentDetail.Amount,
                OrderId = paymentDetail.OrderId,
            };
        }
        public static UpdatePaymentDetailViewModel ToUpdateViewModel(this PaymentDetailViewModel paymentDetail)
        {
            return new UpdatePaymentDetailViewModel
            {
                Id = paymentDetail.Id,
                Method = paymentDetail.Method,
                PaymentDate = paymentDetail.PaymentDate,
                Amount = paymentDetail.Amount,
                OrderId = paymentDetail.OrderId,
            };
        }
        public static PaymentDetail ToEntity(this CreatePaymentDetailViewModel paymentDetail)
        {
            return new PaymentDetail
            {
                Method = paymentDetail.Method,
                PaymentDate = paymentDetail.PaymentDate,
                Amount = paymentDetail.Amount,
                OrderId = paymentDetail.OrderId,
            };
        }
        public static PaymentDetail ToEntity(this UpdatePaymentDetailViewModel paymentDetail)
        {
            return new PaymentDetail
            {
                Id= paymentDetail.Id,
                Method = paymentDetail.Method,
                PaymentDate = paymentDetail.PaymentDate,
                Amount = paymentDetail.Amount,
                OrderId = paymentDetail.OrderId,
            };
        }
    }
}
