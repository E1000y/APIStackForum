using DAL.UOW.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW.Repositories
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<bool> DeleteBySubjectIdAsync(int id);
        Task<IEnumerable<Answer>> GetAnswersBySubjectIdAsync(int SubjectId);
    }
}
