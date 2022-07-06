using Microsoft.Extensions.DependencyInjection;
using MyShop.Core.Interfaces;
using MyShop.Core.Services;

namespace MyShop.Core
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}