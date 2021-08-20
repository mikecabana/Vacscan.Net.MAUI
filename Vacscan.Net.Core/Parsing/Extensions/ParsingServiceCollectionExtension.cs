using Vacscan.Net.Core.Parsing;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ParsingServiceCollectionExtension
    {
        public static IServiceCollection AddTransientVaccinationPassportParser<T>(this IServiceCollection services)
            where T : class, IVaccinationPassportParser
        {
            services.AddTransient<IVaccinationPassportParser, T>();

            return services;
        }

        public static IServiceCollection AddSingletonVaccinationPassportParser<T>(this IServiceCollection services)
            where T : class, IVaccinationPassportParser
        {
            services.AddSingleton<IVaccinationPassportParser, T>();

            return services;
        }

        public static IServiceCollection AddScopedVaccinationPassportParser<T>(this IServiceCollection services)
            where T : class, IVaccinationPassportParser
        {
            services.AddScoped<IVaccinationPassportParser, T>();

            return services;
        }
    }
}
