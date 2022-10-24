using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UOW;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace BLLS
{
    public class ForumService : IForumService
    {
        /*
        public List<Subject> subjects = new List<Subject>()
        {
          
            new Subject(){ Id = 1, Name = "Subject1", Description = "Description1", CreationDate = DateTime.Now, writerId = 1, categoryId = 1 },
            new Subject(){ Id = 2, Name = "Subject2", Description = "Description2", CreationDate = DateTime.Now, writerId = 2, categoryId = 1 },
            new Subject(){ Id = 3, Name = "Subject3", Description = "Description3", CreationDate = DateTime.Now, writerId = 1, categoryId = 2},
            new Subject(){ Id = 4, Name = "Subject4", Description = "Description4", CreationDate = DateTime.Now, writerId = 2,  categoryId = 3},
            new Subject(){ Id = 5, Name = "Subject5", Description = "Description5", CreationDate = DateTime.Now, writerId = 1,  categoryId = 4},
            new Subject(){ Id = 6, Name = "Subject6", Description = "Description6", CreationDate = DateTime.Now, writerId = 2,  categoryId = 5},
            new Subject(){ Id = 7, Name = "Subject7", Description = "Description7", CreationDate = DateTime.Now, writerId = 1,  categoryId = 1 },
            new Subject(){ Id = 8, Name = "Subject8", Description = "Description8", CreationDate = DateTime.Now, writerId = 2,  categoryId = 2},
        };*/

/*
        public List<Answer> answers = new List<Answer>()
        {
            new Answer(){ Id = 1, Body = "BodyAnswer1", CreationDate = DateTime.Now, writerId = 1, subjectId = 1},
            new Answer(){ Id = 2, Body = "BodyAnswer2", CreationDate = DateTime.Now, writerId = 1, subjectId = 1},
            new Answer(){ Id = 3, Body = "BodyAnswer3", CreationDate = DateTime.Now, writerId = 1, subjectId = 2},
            new Answer(){ Id = 4, Body = "BodyAnswer4", CreationDate = DateTime.Now, writerId = 2, subjectId = 1},
            new Answer(){ Id = 5, Body = "BodyAnswer5", CreationDate = DateTime.Now, writerId = 2, subjectId = 2}
        };
*/
/*
        public List<Category> categories = new List<Category>()
        {
            new Category()
            {
                Id = 1, Title = "Category1"
            },
            new Category()
            {
                Id = 2, Title = "Category2"
            },
            new Category()
            {
                Id = 3, Title = "Category3"
            },
            new Category()
            {
                Id = 4, Title = "Category4"
            },
            new Category()
            {
                Id = 5, Title = "Category5"
            },
        };
*/

        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _config;

        
        public ForumService(IUnitOfWork uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
        }


        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            return await _uow.Subject.GetAllAsync();
        }
        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _uow.Subject.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByCategoryId(int categoryId)
        {
            return await _uow.Subject.GetByCategoryIdAsync(categoryId);
        }
        public async Task<Subject> CreateSubjectAsync(Subject newSubject)
        {
            return await _uow.Subject.AddAsync(newSubject);
        }

       

        public async Task<Subject> ModifySubjectAsync(Subject modifiedSubject)
        {
            //await Task.Delay(0);

            //Subject subjectFound = null;

            //foreach (Subject subject in subjects)
            //{
            //    if (subject.Id == modifiedSubject.Id)
            //    {
            //        subjectFound = subject;
            //    }
            //}
            //if (subjectFound == null) return null;

            //subjectFound.Name = modifiedSubject.Name;
            //subjectFound.Description = modifiedSubject.Description;
            //subjectFound.writerId = modifiedSubject.writerId;
            //subjectFound.CreationDate = modifiedSubject.CreationDate;
            //subjectFound.categoryId = modifiedSubject.categoryId;

            //return subjectFound;

            return await _uow.Subject.UpdateAsync(modifiedSubject);

        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {

            _uow.BeginTransaction();

            bool suppressedAnswer = await _uow.Answer.DeleteBySubjectIdAsync(id);
            bool suppressedSubject = await _uow.Subject.DeleteAsync(id);

            if (suppressedAnswer && suppressedSubject)
            {
                _uow.Commit();
                return true;
            }
            else _uow.RollBack();


            return false;
        }

        public async Task<IEnumerable<Answer>> GetAnswersAsync()
        {
            await Task.Delay(0);
            return await _uow.Answer.GetAllAsync();
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            return await _uow.Answer.GetByIdAsync(id);
        }


        public async Task<Answer> CreateAnswerAsync(Answer newAnswer)
        {
            //await Task.Delay(0);
            //int lastId = 0;
            //foreach (Answer ans in answers)
            //{
            //    if (lastId < ans.Id) lastId = ans.Id;
            //}
            //lastId++;

            //newAnswer.Id = lastId;

            //try
            //{
            //    answers.Add(newAnswer);
            //    return newAnswer;
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}

            return await _uow.Answer.AddAsync(newAnswer);
        }

        public async Task<Answer> ModifyAnswerAsync(Answer modifiedAnswer)
        {
            //await Task.Delay(0);
            //Answer answerFound = null;

            //foreach (Answer ans in answers)
            //{
            //    if (ans.Id == modifiedAnswer.Id)
            //    {
            //        answerFound = ans;
            //    }
            //}
            //if (answerFound == null) return null;

            //answerFound.Body = modifiedAnswer.Body;
            //answerFound.subjectId = modifiedAnswer.subjectId;
            //answerFound.writerId = modifiedAnswer.writerId;
            //answerFound.CreationDate = modifiedAnswer.CreationDate;

            //return answerFound;

            return await _uow.Answer.UpdateAsync(modifiedAnswer);
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            //await Task.Delay(0);
            //Answer answerFound = null;

            //foreach (Answer ans in answers)
            //{
            //    if (ans.Id == id)
            //    {
            //        answerFound = ans;
            //    }
            //}
            //if (answerFound == null) return false;
            //answers.Remove(answerFound);


            return await _uow.Answer.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            await Task.Delay(0);
            return await _uow.Category.GetAllAsync() ;
        }

        public async Task<Category> GetCategoryById(int id)
        {

            return await _uow.Category.GetByIdAsync(id) ;
        }


        public async Task<IEnumerable<Answer>> GetAnswersBySubjectIdAsync(int SubjectId)
        {
            return await _uow.Answer.GetAnswersBySubjectIdAsync(SubjectId);
        }
    }


}
