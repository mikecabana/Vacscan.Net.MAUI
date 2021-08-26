using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vacscan.Net.SHC.JWT;
using Vacscan.Net.SHC.JWT.Models;

namespace Vacscan.Net.SHC.Test;

[TestClass]
public class SmartHealthCardVaccinationPassportParserTest
{
    [TestMethod]
    public async Task TestMethod1()
    {
        var raw = "${SHC_RAW}";

        var parsor = new SmartHealthCardVaccinationPassportParser(new[] {
            new StaticSmartHealthCardJWKProvider(new JWK{
                Kid = "qFdl0tDZK9JAWP6g9_cAv57c3KWxMKwvxCrRVSzcxvM",
                X = "XSxuwW_VI_s6lAw6LAlL8N7REGzQd_zXeIVDHP_j_Do",
                Y = "88-aI4WAEl4YmUpew40a9vq_w5OcFvsuaKMxJRLRLL0"
            })
        });

        var result = await parsor.TryParseVaccinationPassportAsync(raw);
    }
}
