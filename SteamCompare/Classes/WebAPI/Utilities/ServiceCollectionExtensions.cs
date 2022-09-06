using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SteamCompare.Classes.WebAPI.Utilities
{ 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSteamWebInterfaceFactory(this IServiceCollection services, Action<SteamWebInterfaceFactoryOptions> options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Singleton<ISteamWebInterfaceFactory, SteamWebInterfaceFactory>());
            services.Configure(options);

            return services;
        }
    }
}