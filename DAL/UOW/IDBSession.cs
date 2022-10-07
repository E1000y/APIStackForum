using System.Data;

namespace DAL.UOW
{
    internal interface IDBSession
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }

    }
}