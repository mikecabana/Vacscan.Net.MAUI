using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vacscan.Net.Core.Parsing;
using Vacscan.Net.SHC;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SHCServiceCollectionExtension
    {
        public static IServiceCollection AddSHCVaccinationPassport(this IServiceCollection services)
        {
            if(!services.Any((sd) => sd.ServiceType == typeof(IVaccinationPassportParser) && sd.ImplementationType == typeof(SmartHealthCardVaccinationPassportParser)))
            {
                services.AddSingletonVaccinationPassportParser<SmartHealthCardVaccinationPassportParser>();
            }

            return services;
        }
    }
}
