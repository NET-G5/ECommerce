namespace Ecommerce.Domain.Interfaces;

public interface ICommonRepository
{
    ICategoryRepository Categories { get; }
    ICustomerRepository Customers { get; }
    IOrderItemRepository OrderItems { get; }
    IOrderRepository Orders { get; }
    IPaymentDetailRepository PaymentDetails { get; }
    IProductRepository Products { get; }
    IReviewRepository Reviews { get; }
    IShippingDetailRepository ShippingDetails { get; }
    IWishListRepository WishLists { get; }
    int SaveChanges();
}
