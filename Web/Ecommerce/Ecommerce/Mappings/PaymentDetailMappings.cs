using Ecommerce.Domain.Entities;
using Ecommerce.ViewModels.PaymentDetail;

namespace Ecommerce.Mappings
{
    public static class PaymentDetailMappings
    {
        public static ViewModels.PaymentDetail.PaymentDetailViewModel ToViewModel(this Domain.Entities.PaymentDetailViewModel paymentDetail)
        {
            return new ViewModels.PaymentDetail.PaymentDetailViewModel
            {
                Id = paymentDetail.Id,
                Method = paymentDetail.Method,
                PaymentDate = paymentDetail.PaymentDate,
                Amount = paymentDetail.Amount,
                OrderId = paymentDetail.OrderId,
            };
        }
        public static UpdatePaymentDetailViewModel ToUpdateViewModel(this ViewModels.PaymentDetail.PaymentDetailViewModel paymentDetail)
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
        public static Domain.Entities.PaymentDetailViewModel ToEntity(this CreatePaymentDetailViewModel paymentDetail)
        {
            return new Domain.Entities.PaymentDetailViewModel
            {
                Method = paymentDetail.Method,
                PaymentDate = paymentDetail.PaymentDate,
                Amount = paymentDetail.Amount,
                OrderId = paymentDetail.OrderId,
            };
        }
        public static Domain.Entities.PaymentDetailViewModel ToEntity(this UpdatePaymentDetailViewModel paymentDetail)
        {
            return new Domain.Entities.PaymentDetailViewModel
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
