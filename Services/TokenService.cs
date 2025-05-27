using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SENAI_Notes.Models;

namespace SENAI_Notes.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            var key = Encoding.ASCII.GetBytes("nossa-chave-secreta-mega-master-ultra-segura-stack-group-senai");
            var chave = new SymmetricSecurityKey(key);
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "SenaiNotes",
                audience: "SenaiNotes",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

//public static class TokenService
//{
//    public static string GenerateToken(NotesUser user)
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();
//        var key = Encoding.ASCII.GetBytes("nossa-chave-secreta-mega-master-ultra-segura-senai");

//        var tokenDescriptor = new SecurityTokenDescriptor
//        {
//            Subject = new ClaimsIdentity(new[]
//            {
//            new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()), // Changed from "Id" to "IdUser"
//            new Claim(ClaimTypes.Email, user.Email)
//        }),
//            Expires = DateTime.UtcNow.AddHours(2),
//            SigningCredentials = new SigningCredentials(
//                new SymmetricSecurityKey(key),
//                SecurityAlgorithms.HmacSha256Signature)
//        };

//        var token = tokenHandler.CreateToken(tokenDescriptor);
//        return tokenHandler.WriteToken(token);
//    }
//}
//}