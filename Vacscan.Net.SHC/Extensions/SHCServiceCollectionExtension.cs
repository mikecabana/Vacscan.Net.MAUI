using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using Vacscan.Net.Core.Parsing;
using Vacscan.Net.SHC;
using Vacscan.Net.SHC.Immunization.Issuance;
using Vacscan.Net.SHC.Immunization.Vaccination;
using Vacscan.Net.SHC.Standard.JWT;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SHCServiceCollectionExtension
    {
        public static IServiceCollection AddSmartHealthCardSupport(this IServiceCollection services)
        {
            services.AddVacScanParsingServices();

            if (!services.Any((sd) => sd.ServiceType == typeof(IImmunizationPassportParser) && sd.ImplementationType == typeof(SmartHealthCardImmunizationPassportParser)))
            {
                services.AddTransient<IImmunizationPassportParser, SmartHealthCardImmunizationPassportParser>();
            }

            services.TryAddSingleton<JWTSmartHealthCardValidator>();
            services.TryAddSingleton<JWTSmartHealthCardParser>();

            services.TryAddTransient<SmartHealthCardIssuerResolver>();
            services.TryAddTransient<SmartHealthCardEntryVaccineResolver>();

            return services;
        }
    }
}
