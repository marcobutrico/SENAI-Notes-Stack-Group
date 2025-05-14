using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

//namespace SENAI_Notes.Services
//{
//    public class TokenService
//    {
//        public string GenerateToken(string email)
//        {
//            // Claims - informacoes do usuário que quero guardar
//            // Definição das informações (claims) que serão armazenadas no token
//            var claims = new[]
//            {
//            new Claim(ClaimTypes.Email, email)
//        };

//            // Criação da chave secreta utilizada para assinar o token
//            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nossa-chave-secreta-mega-master-ultra-segura-senai"));


//            // Definição das credenciais de assinatura usando o algoritmo HmacSha256 (keyed-hash message authentication code)
//            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

//            // Criação do token JWT com emissor, audiência, claims e tempo de expiração
//            var token = new JwtSecurityToken(
//                issuer: "Ecommerce",
//                audience: "Ecommerce",
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(30),  //timeout de token - 30 min
//                signingCredentials: creds
//            );

//            // Retorna o token em formato string
//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}
