using Microsoft.Extensions.DependencyInjection.Extensions;
using Vacscan.Net.Core.Parsing;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ParsingServiceCollectionExtension
    {
        public static IServiceCollection AddVacScanParsingServices(this IServiceCollection services)
        {
            services.TryAddTransient<ImmunizationPassportParser>();
            return services;
        }
    }
}
