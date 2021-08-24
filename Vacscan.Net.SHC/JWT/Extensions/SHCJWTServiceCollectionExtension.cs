using Vacscan.Net.SHC.JWT;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SHCJWTServiceCollectionExtension
    {
        public static IServiceCollection AddTransientSmartHealthCardJWKProvider<T>(this IServiceCollection services)
            where T : class, ISmartHealthCardJWKProvider
        {
            return services.AddTransient<ISmartHealthCardJWKProvider, T>();
        }

        public static IServiceCollection AddScopedSmartHealthCardJWKProvider<T>(this IServiceCollection services)
            where T : class, ISmartHealthCardJWKProvider
        {
            return services.AddScoped<ISmartHealthCardJWKProvider, T>();
        }

        public static IServiceCollection AddSingletonSmartHealthCardJWKProvider<T>(this IServiceCollection services)
            where T : class, ISmartHealthCardJWKProvider
        {
            return services.AddSingleton<ISmartHealthCardJWKProvider, T>();
        }
    }
}
