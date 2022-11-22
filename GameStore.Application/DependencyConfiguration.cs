using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GameStore.Application.External.MediaStorage;

namespace GameStore.Application
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGenreService, GenreService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            var settings = configuration.GetSection(AccountSettings.SectionName);
            services.Configure<AccountSettings>(options =>
            {
                options.ApiKey = settings[nameof(AccountSettings.ApiKey)];
                options.ApiSecret = settings[nameof(AccountSettings.ApiSecret)];
                options.Cloud = settings[nameof(AccountSettings.Cloud)];
            });

            services.AddTransient<IExternalMediaStorage, CloudinaryStorage>();

            return services;
        }
    }
}
