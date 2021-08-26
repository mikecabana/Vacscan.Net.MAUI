using System;
using System.Collections.Generic;
using Vacscan.Net.SHC.Standard.JWT;

namespace Vacscan.Net.SHC.Immunization.Issuance.Internal
{
    public class SmartHealthCardIssuerConfiguration
    {
        public static readonly object IssuerPropertyKey = typeof(SmartHealthCardIssuerConfiguration);

        public List<string> IssuerAuthorities { get; } = new List<string>();
        
        public List<JWK> JWKs { get; } = new List<JWK>();

        public SmartHealthCardIssuerConfiguration AddJwk(JWK jWK)
        {
            JWKs.Add(jWK);
            return this;
        }

        public SmartHealthCardIssuerConfiguration AddJwk(string kid, JWK jWK)
        {
            jWK.Kid = kid;
            JWKs.Add(jWK);
            return this;
        }

        public SmartHealthCardIssuerConfiguration AddAuthority(string authority)
        {
            IssuerAuthorities.Add(authority);
            return this;
        }

        public SmartHealthCardIssuerConfiguration AddAuthority(Uri issuer)
        {
            return AddAuthority(issuer.Authority);
        }
    }
}
