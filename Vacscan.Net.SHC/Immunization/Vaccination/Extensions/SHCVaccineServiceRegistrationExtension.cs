using System;
using Vacscan.Net.SHC.Immunization.Issuance.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SHCVaccineServiceRegistrationExtension
    {
        public static VaccineServiceRegistration ConfigureSmartHealthCard(this VaccineServiceRegistration registration, Action<SmartHealthCardVaccineConfiguration> setup)
        {
            registration.AddSmartHealthCardSupport();

            var configuration = registration.Instance.GetProperty<SmartHealthCardVaccineConfiguration>(SmartHealthCardVaccineConfiguration.IssuerPropertyKey);
            if(configuration == null)
            {
                configuration = new SmartHealthCardVaccineConfiguration();
                registration.Instance.SetProperty(SmartHealthCardVaccineConfiguration.IssuerPropertyKey, configuration);
            }

            setup?.Invoke(configuration);

            return registration;
        }
    }
}
