using DAL.UOW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly IDBSession _dbSession;

        public UnitOfWork(IDBSession dbSession)
        {
            _dbSession = dbSession;
        }

        public void BeginTransaction()
        {
            _dbSession.Transaction = _dbSession.Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbSession.Transaction != null)
                _dbSession.Transaction.Commit();
            _dbSession.Transaction = null;
        }

        public void RollBack()
        {
            //Le Point ? remplace le if 
            _dbSession.Transaction?.Rollback();
            _dbSession.Transaction = null;
        }

        public void Dispose()
        {
            Commit();
        }

        public ICategoryRepository Category { get => new CategoryRepository(_dbSession); }

        public IAnswerRepository Answer { get => new AnswerRepository(_dbSession); }

        public ISubjectRepository Subject { get => new SubjectRepository(_dbSession); }

        public IWriterRepository Writer { get => new WriterRepository(_dbSession); }
    }
}
