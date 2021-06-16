using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hicas_training.Token
{
    public class TokenGenerator
    {
         internal string GenerateToken(List<Claim> claims = null)
         {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication"));
            SigningCredentials credentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256); ;

             SecurityToken token = new JwtSecurityToken(
                issuer: "localhost:5001",
                 audience: "localhost:3000",
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(60),
                 signingCredentials: credentials
             ); ; ;
             return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
