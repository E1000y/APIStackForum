using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLS
{
    public interface IForumService
    {
        Task<Answer> CreateAnswerAsync(Answer newAnswer);
        Task<Subject> CreateSubjectAsync(Subject newSubject);
        Task<bool> DeleteAnswerAsync(int id);
        Task<bool> DeleteSubjectAsync(int id);
        Task<Answer> GetAnswerByIdAsync(int id);
        Task<IEnumerable<Answer>> GetAnswersAsync();
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        Task<Answer> ModifyAnswerAsync(Answer modifiedAnswer);
        Task<Subject> ModifySubjectAsync(Subject modifiedSubject);

        Task<IEnumerable<Subject>> GetSubjectsByCategoryId(int categoryId);

        Task<IEnumerable<Answer>> GetAnswersBySubjectIdAsync(int SubjectId);
    }
}