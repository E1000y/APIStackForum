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
using Domain.Entities;
using DAL.UOW;
using System.Security.Cryptography;

namespace BLLS
{



    public class SecurityService : ISecurityService
    {

        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _uow;
        public SecurityService(IConfiguration configuration, IUnitOfWork uow)
        {
            _configuration = configuration;
            _uow = uow;

        }

        /// <summary>
        /// Renvoie le token généré par le serveur
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public async Task<string> SigningAsync(string username, string password)
        {
            // Vérifier si l'utilisateur existe ou non




            Writer writer = await GetWriterAsync(username);

            if (writer is null ||!(await VerifyPasswordAsync(password, writer.Password))) throw new AuthenticationFailException();
           



            if (writer.IsModerator)
            {
                return GenerateJwtToken(writer.Id.ToString(), new List<string>() { "MOD", "USER" });
            }
            else
            {
                return GenerateJwtToken(writer.Id.ToString(), new List<string>() { "USER" });
            }

            // Générer le token avec les bons rôles

            //Renvoie le token ou AuthenticationFailException
            throw new AuthenticationFailException();

        }

        private string GenerateJwtToken(string id, List<string> roles)
        {
            //Add User Infos
            var claims = new List<Claim>(){
                         new Claim(JwtRegisteredClaimNames.Sub, id),
                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                         new Claim(ClaimTypes.NameIdentifier, id)
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

        public async Task<Writer> GetWriterAsync(string username)
        {
            return await _uow.Writer.GetByUserNameAsync(username);
        }

        public async Task<Writer> CreateWriterAsync(Writer newWriter)
        {
            //Hasher le mot de passe
            newWriter.Password = await HashPasswordAsync(newWriter.Password);

            return await _uow.Writer.AddAsync(newWriter);

        }

        private async Task<string> HashPasswordAsync(string password)
        {
            // Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);



            // Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);



            // Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);



            // Turn the combined salt+hash into a string for storage
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        private async Task<bool> VerifyPasswordAsync(string givenPassword, string savedPassword)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(givenPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            bool result = true;
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    result = false;



            return result;
        }

        public async Task<bool> ModifyPasswordAsync(int id, string OldPassword, string NewPassword)
        {
            Writer writer = await _uow.Writer.GetByIdAsync(id);

            if (!(await VerifyPasswordAsync(OldPassword, writer.Password)))
            {
                throw new AuthenticationFailException();
            }

            return await _uow.Writer.ModifyWriterPasswordAsync(id, await HashPasswordAsync(NewPassword));
            

        }
    }
}
