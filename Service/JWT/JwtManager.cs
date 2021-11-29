using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.JWT
{
    public class JwtManager : IJwtManager
    {

        private readonly JwtSettings _jwtsettings;
        private string key = "";

        public JwtManager(IOptions<JwtSettings> jwtsettings)
        {
            _jwtsettings = jwtsettings.Value;
            key = _jwtsettings.Secret;
        }
        public string Authentication(string id, string username, string password, string[] roles)
        {
            
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.NameIdentifier, id) };
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r.ToString()));
            claims.AddRange(roleClaims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);
        }
    }
}
