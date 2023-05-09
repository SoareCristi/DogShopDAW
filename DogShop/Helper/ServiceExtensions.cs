//using DogShop.Data.UitOfWork;
using DogShop.Data;
using DogShop.Helper;
using DogShop.Repositories;
using DogShop.Services;

namespace DogShop.Helper.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWishlistRepository, WishlistRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWishlistService, WishlistService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            return services;
        }

        public static IServiceCollection AddJwtUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }

    }
}
