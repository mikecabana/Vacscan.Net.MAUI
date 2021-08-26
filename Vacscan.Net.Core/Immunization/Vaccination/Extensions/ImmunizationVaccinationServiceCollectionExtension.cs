using Microsoft.Extensions.DependencyInjection.Extensions;
using Vacscan.Net.Core.Immunization.Vaccination;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ImmunizationVaccinationServiceCollectionExtension
    {
        public static VaccineServiceRegistration AddVaccine(this IServiceCollection services, string key, string label)
        {
            return services.AddVaccine(new Vaccine(key, label));
        }

        public static VaccineServiceRegistration AddVaccine(this IServiceCollection services, Vaccine vaccine)
        {
            var builder = new VaccineServiceRegistration(services, vaccine);
            services.AddVaccineProvider(builder);

            return builder;
        }

        public static IServiceCollection AddVaccineProvider(this IServiceCollection services, IVaccineProvider vaccineProvider)
        {
            services.TryAddSingleton<VaccineProvider>();
            return services.AddSingleton<IVaccineProvider>(vaccineProvider);
        }
    }
}
