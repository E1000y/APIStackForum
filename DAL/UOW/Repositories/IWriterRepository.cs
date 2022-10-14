using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
   public interface IWriterRepository : IGenericRepository<Writer>
    {

        Task<Writer> GetByUserNameAndPasswordAsync(string username, string password);
        Task<bool> ModifyWriterPasswordAsync(int id, string password);

    }
}
