using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GameStore.Persistence.Identity;
using GameStore.Persistence.Context;
using System.Reflection;

namespace GameStore.Persistence
{
    public static class DependencyConfiguration
    {
        private const string ConnectionString = "GameStoreDb";
        
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(ConnectionString),
                builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
