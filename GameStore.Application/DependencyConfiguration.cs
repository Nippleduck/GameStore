using GameStore.Application.Interfaces;
using GameStore.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GameStore.Application
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGenreService, GenreService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
