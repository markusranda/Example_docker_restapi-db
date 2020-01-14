using System;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Supermarket.API.Security.Tokens {

    public class SigningConfigurations {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            using(var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
                Console.WriteLine(provider.ToXmlString(false));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256);
        }

    }

}