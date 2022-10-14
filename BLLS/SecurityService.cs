using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace BLLS
{



   public class SecurityService : ISecurityService
    {

        private readonly IConfiguration _configuration;
        public SecurityService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        /// <summary>
        /// Renvoie le token généré par le serveur
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public string Signing(string username, string password)
        {
            // Vérifier si l'utilisateur existe ou non
            if (username == "admin" && password == "admin")
            {
                return GenerateJwtToken("admin", new List<string>() { "ADMIN", "USER" });
            }
            else if (username == "user" && password == "user")
            {
                return GenerateJwtToken("user", new List<string>() { "USER" });
            }

            // Générer le token avec les bons rôles

            //Renvoie le token ou AuthenticationFailException
            throw new AuthenticationFailException();

        }

        private string GenerateJwtToken(string username, List<string> roles)
        {
            //Add User Infos
            var claims = new List<Claim>(){
                         new Claim(JwtRegisteredClaimNames.Sub, username),
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                         new Claim(ClaimTypes.NameIdentifier, username)
 };
            //Add Roles
            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });
            //Signin Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //Expiration time
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));
            //Create JWT Token Object
            var token = new JwtSecurityToken(
            _configuration["JwtIssuer"],
            _configuration["JwtIssuer"],
            claims,
            expires: expires,
            signingCredentials: creds
            );
            //Serializes a JwtSecurityToken into a JWT in Compact Serialization Format.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
