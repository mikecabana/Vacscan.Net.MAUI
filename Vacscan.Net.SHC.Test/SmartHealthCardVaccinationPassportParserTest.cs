using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vacscan.Net.Core.Immunization.Issuance;
using Vacscan.Net.Core.Immunization.Vaccination;
using Vacscan.Net.Core.Parsing;
using Vacscan.Net.SHC.Standard.JWT;

namespace Vacscan.Net.SHC.Test;

[TestClass]
public class SmartHealthCardVaccinationPassportParserTest
{
    [TestMethod]
    public async Task TestMethod2()
    {
        var services = new ServiceCollection();

        services
            .AddVaccine(Vaccine.Covid19Astrazeneca)
            .ConfigureSmartHealthCard((options) => {
                options.AddCvxCode(210);
            });

        services
            .AddVaccine(Vaccine.Covid19Moderna)
            .ConfigureSmartHealthCard((options) => {
                options.AddCvxCode(207);
            });

        services
            .AddVaccine(Vaccine.Covid19Pfizer)
            .ConfigureSmartHealthCard((options) => {
                options.AddCvxCode(208);
            });

        services
            .AddIssuer(Issuer.EuropeanUnion);

        services
            .AddIssuer(Issuer.CanadaQuebec)
            .ConfigureSmartHealthCard((options) => {
                options.AddAuthority("covid19.quebec.ca");
                //options.AddJwk("qFdl0tDZK9JAWP6g9_cAv57c3KWxMKwvxCrRVSzcxvM", new JWK {
                //    X = "XSxuwW_VI_s6lAw6LAlL8N7REGzQd_zXeIVDHP_j_Do",
                //    Y = "88-aI4WAEl4YmUpew40a9vq_w5OcFvsuaKMxJRLRLL0"
                //});
            });

        var serviceProvider = services.BuildServiceProvider();
        var parsor = serviceProvider.GetRequiredService<ImmunizationPassportParser>();

        var raw = "<shc qr code here>";
        
        var result = await parsor.TryParseImmunizationPassportAsync(raw);
    }
}