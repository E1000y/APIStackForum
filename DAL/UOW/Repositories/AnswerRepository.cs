
using Dapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    internal class AnswerRepository : IAnswerRepository
    {
        private readonly IDBSession _dbsession;

        public AnswerRepository(IDBSession dbsession)
        {
            _dbsession = dbsession;
        }

        public Task<Answer> AddAsync(Answer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            string query = @"SELECT * FROM Answer";

            IEnumerable<Answer> result = await _dbsession.Connection.QueryAsync<Answer>(query, transaction: _dbsession.Transaction);
            return result;
        }

        public Task<Answer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Answer> UpdateAsync(Answer entity)
        {
            throw new NotImplementedException();
        }
    }
}
