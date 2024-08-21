using Ecommerce.Domain.Enums;

namespace Ecommerce.ViewModels.PaymentDetail
{
    public class CreatePaymentDetailViewModel
    {
        public PaymentMethod Method { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; }
    }
}
