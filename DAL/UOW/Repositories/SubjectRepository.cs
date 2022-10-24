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
    class SubjectRepository : ISubjectRepository
    {

        private readonly IDBSession _dbsession;

        public SubjectRepository(IDBSession dbsession)
        {
            _dbsession = dbsession;
        }

        public async Task<Subject> AddAsync(Subject entity)
        {
            string query = @"INSERT INTO Subject (Name, description, creationDate, writerId, categoryId)
                OUTPUT INSERTED.ID
                VALUES(@name, @description, @creationDate, @writerId, @categoryId) ";

            int? idInserted = await _dbsession.Connection.ExecuteScalarAsync<int?>(query, new
            {
                Name = entity.Name,
                description = entity.Description,
                creationDate = entity.CreationDate,
                writerId = entity.writerId,
                categoryId = entity.categoryId
            });

            if (!idInserted.HasValue) throw new InsertSQLFailureException(entity);
            entity.Id = idInserted.GetValueOrDefault();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {


            string query = @"DELETE FROM Subject WHERE id = @id";

            int nblinesaffected = await _dbsession.Connection.ExecuteAsync(query, new { id = id }, transaction: _dbsession.Transaction);

            return nblinesaffected == 1;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            string query = @"SELECT * FROM Subject";

            IEnumerable<Subject> result = await _dbsession.Connection.QueryAsync<Subject>(query, transaction: _dbsession.Transaction);
            return result;
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Subject WHERE id = @id";

            Subject subject = await _dbsession.Connection.QueryFirstOrDefaultAsync<Subject>(query, new { id = id }, transaction: _dbsession.Transaction);

            return subject;
        }

        public async Task<Subject> UpdateAsync(Subject entity)
        {
            string query = @"UPDATE Subject SET Name = @name, description = @description, creationDate = @creationDate, writerId = @writerId, categoryId = @categoryId where id = @id";

            int nbLinesModified = await _dbsession.Connection.ExecuteAsync(query, new
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                creationDate = entity.CreationDate,
                writerId = entity.writerId,
                categoryId = entity.categoryId
            }, transaction: _dbsession.Transaction);

            if (nbLinesModified != 1) throw new UpdateSQLFailureException(entity);
            return await GetByIdAsync(entity.Id);
        }

        
    }
}
