using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Billing.Authentication.Domains.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "MyIssuer";
        public const string AUDIENCE = "MyAudience";
        const string KEY = "ThereIsSecurityKey";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
