using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.CORE.Repository;
using OnlineShop.DOMAIN.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.AUTH.Interfaces;
using OnlineShop.CORE.EF;
using OnlineShop.DATA.Entities;
using token.AUTH.Services;
using token.AUTH.Interfaces;

namespace OnlineShop.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IJwtGenerator, JwtGenerator>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<TContext>();

            return services;
        }
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
           services.AddCors(options => {
               options.AddPolicy("AllowAll", builder =>
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
           });

    }
}
