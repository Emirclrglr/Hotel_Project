using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenGenerator()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi_1.2.4.67.d.a.431.ds.5423.aaaa");

            SymmetricSecurityKey key = new(bytes);

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.UtcNow, expires: DateTime.Now.AddMinutes(3), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new();

            return handler.WriteToken(token);
        }

        public string AdminTokenGenerator()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi_1.2.4.67.d.a.431.ds.5423.aaaa");

            SymmetricSecurityKey key = new(bytes);

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Visitor")
            };

            JwtSecurityToken token = new(issuer: "http://localhost", audience: "http://localhost", claims: claims,notBefore: DateTime.UtcNow, expires: DateTime.Now.AddMinutes(3), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new();

            return handler.WriteToken(token);
        }
    }
}
