using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure.Repositories;

internal class CommonRepository : ICommonRepository
{
    private readonly EcommerceDbContext _context;

    private ICategoryRepository _categoryRepository;
    public ICategoryRepository Categories =>
        _categoryRepository ??= new CategoryRepository(_context);


    private ICustomerRepository _customerRepository;
    public ICustomerRepository Customers => 
        _customerRepository ??= new CustomerRepository(_context);


    private IOrderItemRepository _orderItemRepository;
    public IOrderItemRepository OrderItems =>
        _orderItemRepository ??= new OrderItemRepository(_context);


    private IOrderRepository _orderRepository;
    public IOrderRepository Orders => 
        _orderRepository ??= new OrderRepository(_context);


    private IPaymentDetailRepository _paymentDetail;
    public IPaymentDetailRepository PaymentDetails => 
        _paymentDetail ??= new PaymentDetailRepository(_context);


    private IProductRepository _productRepository;
    public IProductRepository Products => 
        _productRepository ??= new ProductRepository(_context);


    private IReviewRepository _reviewRepository;
    public IReviewRepository Reviews => 
        _reviewRepository ??= new ReviewRepository(_context);


    private IShippingDetailRepository _shippingDetail;
    public IShippingDetailRepository ShippingDetails => 
        _shippingDetail ??= new ShippingDetailRepository(_context); 


    private IWishListRepository _wishListRepository;
    public IWishListRepository WishLists => 
        _wishListRepository ??= new WishListRepository(_context);

    public CommonRepository(EcommerceDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        _categoryRepository = new CategoryRepository(context);
    }

    public int SaveChanges()
        => _context.SaveChanges();
}
