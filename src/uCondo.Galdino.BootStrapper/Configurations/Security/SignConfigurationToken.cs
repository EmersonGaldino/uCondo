using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace uCondo.Galdino.BootStraper.Configurations.Security;

public class SignConfigurationToken
{
    public SecurityKey Key { get; }

    public SigningCredentials SigningCredentials { get; }

    public SignConfigurationToken()
    {
        using (var provider = new RSACryptoServiceProvider(2048))
        {
            Key = new RsaSecurityKey(provider.ExportParameters(true));
        }

        SigningCredentials = new SigningCredentials(
            Key, SecurityAlgorithms.RsaSha256Signature);
    }
}