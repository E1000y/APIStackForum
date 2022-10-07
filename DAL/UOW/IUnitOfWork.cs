using DAL.UOW.Repositories;


namespace DAL.UOW
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ISubjectRepository Subject { get; }
        IAnswerRepository Answer {get;}
        IWriterRepository Writer {get;}

        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}