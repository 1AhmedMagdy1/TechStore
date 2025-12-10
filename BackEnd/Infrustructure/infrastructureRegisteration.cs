using Core.Interfaces;
using Core.Models;
using Infrustructure.Data;
using Infrustructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Core.Services;
using Infrustructure.Repositories.Services;
using StackExchange.Redis;

namespace Infrustructure
{
    public static class infrastructureRegisteration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Database registration
            services.AddDbContext<TechStoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("con")));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<TechStoreContext>().AddDefaultTokenProviders();

            // Repositories registration
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Auth registration
            services.AddScoped<IAuthService, AuthService>();

            //token service
            services.AddScoped<ITokenService, TokenService>();

            //redis registration
            services.AddSingleton<IConnectionMultiplexer>(i =>
            {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("redis")!);
                return ConnectionMultiplexer.Connect(config);
            });

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        
        }
    }
}
