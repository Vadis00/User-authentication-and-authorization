using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using User_authentication.Common.Entities;
using User_authentication.Common.Model;
using User_authentication.DAL;
using User_authentication.Identity.Model;

namespace User_authentication.BLL.Service
{
    public class AuthService
    {
        DataContext db;
        private readonly IOptions<AuthOptions> options;

        public AuthService(DataContext db, IOptions<AuthOptions> options)
        {
            this.db = db; 
            this.options = options;
        }

        public async Task<string> AuthenticateUser(string email, string password)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Login == email) ?? throw new Exception("Not Found");

            if (user.Password != password)
                throw new Exception("The password is incorrect");

            return generateJWT(user);
        }

        private string generateJWT(User user)
        {
            var authParams = options.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Login),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),

            };

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
