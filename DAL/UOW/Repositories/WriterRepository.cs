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
    class WriterRepository : IWriterRepository
    {

        private readonly IDBSession _dbsession;

        public WriterRepository(IDBSession dbsession)
        {
            _dbsession = dbsession;
        }

        public async Task<Writer> AddAsync(Writer entity)
        {
            string query = @"INSERT INTO Writer (firstname, lastname, isModerator, login, password)
                            OUTPUT INSERTED.ID
                            VALUES(@firstname, @lastname, @isModerator, @login, @password)";

            int? idInserted = await _dbsession.Connection.ExecuteScalarAsync<int?>(query,
                new
                {
                    firstname = entity.FirstName,
                    lastname = entity.LastName,
                    isModerator = entity.IsModerator,
                    login = entity.Login,
                    password = entity.Password
                }, transaction: _dbsession.Transaction);

            if (!idInserted.HasValue) throw new InsertSQLFailureException(entity);
            entity.Id = idInserted.GetValueOrDefault();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string query = @"DELETE FROM Writer WHERE id = @id";

            int nblinesaffected = await _dbsession.Connection.ExecuteAsync(query, new { id = id }, transaction: _dbsession.Transaction);

            return nblinesaffected == 1;
        }

        public async Task<IEnumerable<Writer>> GetAllAsync()
        {
            string query = @"SELECT * FROM Writer";
            IEnumerable<Writer> result = await _dbsession.Connection.QueryAsync<Writer>(query, transaction: _dbsession.Transaction);
            return result;
        }

        public async Task<Writer> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM Writer where id= @id";
            Writer writerbyId = await _dbsession.Connection.QueryFirstOrDefaultAsync<Writer>(query, new { id = id }, transaction: _dbsession.Transaction);
            return writerbyId;

        }

        public async Task<Writer> UpdateAsync(Writer entity)
        {
            string query = @"UPDATE Writer SET firstname = @firstname, lastname =@lastname, isModerator = @isModerator, login=@login, password =@password where id = @id";

            int nblinesmodified = await _dbsession.Connection.ExecuteAsync(query, new
            {
                id = entity.Id,
                firstname = entity.FirstName,
                lastname = entity.LastName,
                isModerator = entity.IsModerator,
                login = entity.Login,
                password = entity.Password
            }, transaction: _dbsession.Transaction);

            if (nblinesmodified != 1) throw new UpdateSQLFailureException(entity);
            return await GetByIdAsync(entity.Id);


        }
    }
}
