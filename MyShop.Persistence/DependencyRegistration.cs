using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Core.Entities;
using MyShop.Core.Interfaces;
using MyShop.Persistence.Services;

namespace MyShop.Persistence
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyShopDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyShopDbContext"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;

            })
                .AddEntityFrameworkStores<MyShopDbContext>();

            services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<Discount>, Repository<Discount>>();


            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICurrentUser, CurrentUserService>();
            return services;
        }
    }
}