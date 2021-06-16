// using hicas_training.Models;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;

// namespace hicas_training.Token
// {
//     public class AccessToken
//     {
//         private TokenGenerator _tokenGenerator;
//         private AuthenConfig _configuration;

//         public AccessToken()
//         {

//         }
//         public AccessToken(TokenGenerator tokenGenerator, AuthenConfig configuration)
//         {
//             _tokenGenerator = tokenGenerator;
//             _configuration = configuration;
//         }

//         internal string GenerateToken(User user)
//         {
//             List<Claim> _claims = new List<Claim>()
//             {
//                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
//                 new Claim("id",user.IdUser.ToString()),
//                 new Claim("username",user.Name),
//                 new Claim("Name",user.Name??""),
//                 new Claim("Email",user.Email??""),
//             };
//             return _tokenGenerator.GenerateToken(
//                 _configuration,
//                 _configuration.AccessTokenSecret,
//                 _configuration.AccessTokenExpirationMinutes
//                 /*_claims*/
//                 );
//         }
//         internal bool Validate(string accessToken)
//         {
//             JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
//             try
//             {
//                 TokenValidationParameters validationParameters = new TokenValidationParameters
//                 {
//                     ValidateIssuer = true,
//                     ValidateAudience = true,
//                     ValidateLifetime = true,
//                     ValidateIssuerSigningKey = true,
//                     ValidIssuer = _configuration.ValidIssuer,
//                     ValidAudience = _configuration.ValidAudience,
//                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.AccessTokenSecret)),
//                     RequireExpirationTime = false,
//                     ClockSkew = TimeSpan.Zero,
//                 }; ;
//                 tokenHandler.ValidateToken(accessToken, validationParameters, out SecurityToken validatedToken);
//             }
//             catch (Exception)
//             {
//                 return false;
//             }
//             return true;
//         }
//     }
// }
