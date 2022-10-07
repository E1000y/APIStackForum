using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly IDBSession _dbsession;

        public CategoryRepository(IDBSession dbsession)
        {
            _dbsession = dbsession;
        }
        public Task<Category> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            string query = @"SELECT * FROM Category";

            IEnumerable<Category> result = await _dbsession.Connection.QueryAsync<Category>(query, transaction: _dbsession.Transaction);
            if (result is null) throw new SELECTSQLException();
            return result;


        }

        public async Task<Category> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Category WHERE id = @id";

            Category category = await _dbsession.Connection.QueryFirstOrDefaultAsync<Category>(query, new { id = id }, transaction: _dbsession.Transaction);

            return category;
        }

        public Task<Category> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
