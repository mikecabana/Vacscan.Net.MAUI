using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Vacscan.Net.SHC.Immunization.Issuance.Internal;
using Vacscan.Net.SHC.Standard.JWT;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SHCIssuerServiceRegistrationExtension
    {
        public static IssuerServiceRegistration ConfigureSmartHealthCard(this IssuerServiceRegistration registration, Action<SmartHealthCardIssuerConfiguration> setup)
        {
            registration.AddSmartHealthCardSupport();
            registration.TryAddTransient<IJWTSmartHealthCardJWKProvider, IssuersJWTSmartHealthCardJWKProvider>();

            var configuration = registration.Instance.GetProperty<SmartHealthCardIssuerConfiguration>(SmartHealthCardIssuerConfiguration.IssuerPropertyKey);
            if(configuration == null)
            {
                configuration = new SmartHealthCardIssuerConfiguration();
                registration.Instance.SetProperty(SmartHealthCardIssuerConfiguration.IssuerPropertyKey, configuration);
            }

            setup?.Invoke(configuration);

            return registration;
        }
    }
}
