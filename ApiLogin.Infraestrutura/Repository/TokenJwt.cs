using ApiLogin.Domain.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLogin.Infraestrutura.Repository
{
    public class TokenJwt : ITokenGerado
    {
        public string GerarToken(string token)
        {
            var key = "8ede30b1-e161-45ae-845f-7d93eb57adee";
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,token.ToString())
            };
            var tkn = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(50),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokens = new JwtSecurityTokenHandler();
            var secu = tokens.CreateToken(tkn);
            return tokens.WriteToken(secu);
        }
    }
}
