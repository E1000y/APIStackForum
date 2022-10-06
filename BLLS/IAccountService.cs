using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLS
{
    public interface IAccountService
    {
        Task<Writer> CreateWriterAsync(Writer newWriter);
        Task<bool> DeleteWriterAsync(int id);
        Task<Writer> GetWriterByIdAsync(int id);
        Task<IEnumerable<Writer>> GetWritersAsync();
        Task<Writer> ModifyWriterAsync(Writer modifiedWriter);
    }
}