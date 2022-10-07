using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    class WriterRepository : IWriterRepository
    {

        private readonly IDBSession _dbsession;

        public WriterRepository(IDBSession dbsession)
        {
            _dbsession = dbsession;
        }

        public Task<Writer> AddAsync(Writer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Writer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Writer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Writer> UpdateAsync(Writer entity)
        {
            throw new NotImplementedException();
        }
    }
}
