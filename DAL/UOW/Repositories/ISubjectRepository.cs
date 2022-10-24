using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {

        public  Task<IEnumerable<Subject>> GetByCategoryIdAsync(int categoryId);
    }
}
