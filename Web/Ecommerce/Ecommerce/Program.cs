using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXdedHRQRGRZWEV+WkQ=");

        var connectionString = builder.Configuration.GetConnectionString("ConnectionStringOfBobur");


        builder.Services.AddDbContext<EcommerceDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddScoped<ICommonRepository, CommonRepository>();


        builder.Services.AddScoped<IPaymentDetailRepository, PaymentDetailRepository>();
        builder.Services.AddScoped<IPaymentDetailService, PaymentDetailService>();

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();

        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();

        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        builder.Services.AddScoped<IOrderItemService, OrderItemService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IReviewService, ReviewService>();

        builder.Services.AddScoped<IShippingDetailRepository, ShippingDetailRepository>();
        builder.Services.AddScoped<IShippingDetailService, ShippingDetailService>();

        builder.Services.AddScoped<IWishListRepository, WishListRepository>();
        builder.Services.AddScoped<IWishListService, WishListService>();


        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
