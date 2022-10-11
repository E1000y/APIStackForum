
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
    internal class AnswerRepository : IAnswerRepository
    {
        private readonly IDBSession _dbsession;

        public AnswerRepository(IDBSession dbsession)
        {
            _dbsession = dbsession;
        }

        public async Task<Answer> AddAsync(Answer entity)
        {
            string query = @"INSERT INTO Answer (body, writerId, subjectId, creationDate)
                            OUTPUT INSERTED.ID
                            VALUES(@body, @writerId, @subjectId, @creationDate)";
            int? idInserted = await _dbsession.Connection.ExecuteScalarAsync<int?>(query,
                new
                {
                    body = entity.Body,
                    writerId = entity.writerId,
                    subjectId = entity.subjectId,
                    creationDate = entity.CreationDate
                }, transaction: _dbsession.Transaction);

            if (!idInserted.HasValue) throw new InsertSQLFailureException(entity);
            entity.Id = idInserted.GetValueOrDefault();
            return entity;


        }

        public async Task<bool> DeleteAsync(int id)
        {

            string query = @"DELETE FROM Answer WHERE id = @id";

            int nblinesaffected = await _dbsession.Connection.ExecuteAsync(query, new { id = id }, transaction: _dbsession.Transaction) ;

            return nblinesaffected == 1;
        }

        public async Task<bool> DeleteBySubjectIdAsync(int id)
        {
            string query = @"DELETE FROM Answer WHERE subjectId = @id";

            int nblinesaffected = await _dbsession.Connection.ExecuteAsync(query, new { id = id }, transaction: _dbsession.Transaction);

            return true;
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            string query = @"SELECT * FROM Answer";

            IEnumerable<Answer> result = await _dbsession.Connection.QueryAsync<Answer>(query, transaction: _dbsession.Transaction);
            return result;
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Answer WHERE id = @id";

            Answer Answer = await _dbsession.Connection.QueryFirstOrDefaultAsync<Answer>(query, new { id = id }, transaction: _dbsession.Transaction);

            return Answer;
        }

        public async Task<Answer> UpdateAsync(Answer entity)
        {
            string query = @"UPDATE Answer SET body = @body, subjectId = @subjectId, writerId= @writerId  where id = @id";

            int nbLinesModified = await _dbsession.Connection.ExecuteAsync(query, new
            {
                id = entity.Id,
                body = entity.Body,
                subjectId = entity.subjectId,
                writerId = entity.writerId
            }, transaction: _dbsession.Transaction);

            if (nbLinesModified != 1) throw new UpdateSQLFailureException(entity);

            return await GetByIdAsync(entity.Id);
        }
    }
}
