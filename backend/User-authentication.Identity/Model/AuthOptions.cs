using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace User_authentication.Identity.Model
{
    public class AuthOptions
    {
        // the one who generated the token
        public string Issuer { get; set; }

        // the one for whom the token is intended
        public string Audience { get; set; }

        // The secret string that will be used to generate the symmetric encryption key
        public string Secret { get; set; }

        // Token lifetime in seconds, after the time expires, the token becomes invalid
        public int TokenLifeTime { get; set; }

        // Method for generating an encryption key from a secret
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
