
using Domain.Entities;
using System.Threading.Tasks;

namespace BLLS
{
   public interface ISecurityService
    {
        /// <summary>
        /// Renvoie le Token généré par le serveur
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        Task<string> SigningAsync(string username, string password);
        Task<Writer> CreateWriterAsync(Writer newWriter);
        Task<bool> ModifyPasswordAsync(int id,string OldPassword, string NewPassword);
    }
}