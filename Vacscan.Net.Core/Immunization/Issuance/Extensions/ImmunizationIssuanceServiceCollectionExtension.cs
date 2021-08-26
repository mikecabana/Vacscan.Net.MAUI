using Microsoft.Extensions.DependencyInjection.Extensions;
using Vacscan.Net.Core.Immunization.Issuance;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ImmunizationIssuanceServiceCollectionExtension
    {
        public static IssuerServiceRegistration AddIssuer(this IServiceCollection services, string key, string label)
        {
            return services.AddIssuer(new Issuer(key, label));
        }

        public static IssuerServiceRegistration AddIssuer(this IServiceCollection services, Issuer issuer)
        {
            var builder = new IssuerServiceRegistration(services, issuer);
            services.AddIssuerProvider(builder);

            return builder;
        }

        public static IServiceCollection AddIssuerProvider(this IServiceCollection services, IIssuerProvider issuerProvider)
        {
            services.TryAddSingleton<IssuerProvider>();
            return services.AddSingleton<IIssuerProvider>(issuerProvider);
        }
    }
}
