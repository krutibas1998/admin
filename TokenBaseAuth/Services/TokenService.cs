using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenBaseAuth.DatabaseEntity;

namespace TokenBaseAuth.Services
{
    public class TokenService : ITokenService
    {
        private TimeSpan Expiryduraation = new TimeSpan(20, 30, 0);
        public string BuildToken(string key, string issuer, IEnumerable<string> audience, string UserName, UserRegistration userRegistration)
        {
            var claims = new List<Claim>
            {
            new Claim("UserName",userRegistration.UserName!=null?userRegistration.UserName:""),
            new Claim("Password",userRegistration.Password!=null?userRegistration.Password:""),
            new Claim("UserType",userRegistration.UserType!=null?userRegistration.UserType:"")
            };
            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.Add(Expiryduraation), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
