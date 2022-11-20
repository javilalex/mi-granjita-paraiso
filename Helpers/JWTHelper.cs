using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mi_Granjita_Paraiso.Helpers
{
    public class JWTHelper
    {
        internal static string CreateUserToken(string key, string issuer, string audience, DateTime timeToExpire, IdentityUser user)
        {

            var claims = new List<Claim>()
            {
                new Claim("id", user.Id),
                new Claim("userName", user.UserName),
                new Claim("email", user.Email),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: timeToExpire,
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}