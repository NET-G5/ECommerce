using Ecommerce.Domain.Interfaces;
using Ecommerce.Filters;
using Ecommerce.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddControllers(options =>
        {
            options.Filters.Add(new ExceptionHandlerFilter());
        });

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXdedHRQRGRZWEV+WkQ=");

        var connectionString = builder.Configuration.GetConnectionString("ConnectionStringOfJamshid");

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


        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
        });

        builder.Services
           .AddIdentity<IdentityUser, IdentityRole>(options =>
           {
               options.SignIn.RequireConfirmedAccount = false;
               options.SignIn.RequireConfirmedPhoneNumber = false;

               options.Password.RequireDigit = true;
               options.Password.RequireLowercase = true;
               options.Password.RequireUppercase = true;
               options.Password.RequireNonAlphanumeric = true;
               options.Password.RequiredLength = 8;

               options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
               options.Lockout.MaxFailedAccessAttempts = 5;
               options.Lockout.AllowedForNewUsers = true;

               options.User.RequireUniqueEmail = true;
           })
           .AddEntityFrameworkStores<EcommerceDbContext>()
           .AddDefaultTokenProviders();

        builder.Services
            .AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Products/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Products}/{action=Index}/{id?}");

        app.Run();
    }
}
