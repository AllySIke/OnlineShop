using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;  
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.CORE.EF;

namespace OnlineShop.API.Configurations
{
    public static class DbConnectionConfiguration
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<TContext>(opt =>
                opt.UseSqlServer(conf.GetConnectionString("Auth"), b => b.MigrationsAssembly("OnlineShop.API"))
               // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
               );

            return services;
        }

    }
}
